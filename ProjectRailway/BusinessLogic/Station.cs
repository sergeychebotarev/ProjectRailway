using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRailway.Abstract;
using ProjectRailway.Domains;
using MIConvexHull;
using ProjectRailway.DAL;
using SharpGraph;

namespace ProjectRailway.BusinessLogic
{
    public class Station : RailwayStation
    {
        private readonly IDataLoader _dataLoader;

        public Station(string stationName, IDataLoader dataLoader)
        {
            this.Name = stationName;
            this._dataLoader = dataLoader;
            LoadData();
        }

        private void LoadData()
        {
            var points = _dataLoader.GetPoints();
            var edges = _dataLoader.GetEdges(points);
            var paths = _dataLoader.GetPaths(edges);
            this.Parks = _dataLoader.GetParks(paths);
        }

        public DictionaryEdges GetAllStationEdges()
        {
            var dictionary = new DictionaryEdges();
            var allEdges = Parks
                .SelectMany(park => park.Paths.SelectMany(path => path.Edges))
                .ToList();
            allEdges.ForEach(dictionary.AddEdgeDistinct);

            return dictionary;
        }

        public DictionaryEdges GetAllParkEdges(RailwayPark park)
        {
            var dictionary = new DictionaryEdges();
            var allEdges = park
                .Paths
                .SelectMany(path => path.Edges)
                .ToList();
            allEdges.ForEach(dictionary.AddEdgeDistinct);

            return dictionary;
        }

        public DictionaryPoints GetAllParkPoints(RailwayPark park)
        {
            var dictionary = new DictionaryPoints();
            var allEdges = GetAllParkEdges(park)
                .Values
                .ToList();

            allEdges.ForEach(edge => edge.EnumeratePoints().ToList()
                .ForEach(point => dictionary.AddPointDistinct(point)));

            return dictionary;
        }

        public IList<RailwayPoint> BuildParkOutline(RailwayPark park)
        {
            var points = GetAllParkPoints(park)
                .Values
                .ToList();

            var convexHull = ConvexHull.Create2D(points);

            return convexHull.Result;
        }

        private Graph BuildGraphForEdges(List<Edge> edges, DictionaryEdges dictionaryEdges)
        {
            var graph = new Graph(edges);
            foreach (var edge in edges)
            {
                string key = $"{edge.From().GetLabel()}-{edge.To().GetLabel()}";
                double length = dictionaryEdges[key].Length;
                graph.AddComponent<EdgeWeight>(edge).Weight = (float)length;
            }

            return graph;
        }

        public Graph BuildParkGraph(RailwayPark park)
        {
            var dictionaryEdges = GetAllParkEdges(park);
            var edges = dictionaryEdges
                .Values
                .Select(e => new Edge(e.PointStart.Name, e.PointEnd.Name))
                .ToList();

            return BuildGraphForEdges(edges, dictionaryEdges);
        }

        public Graph BuildStationGraph()
        {
            var dictionaryEdges = GetAllStationEdges();
            var edges = dictionaryEdges
                .Values
                .Select(e => new Edge(e.PointStart.Name, e.PointEnd.Name))
                .ToList();

            return BuildGraphForEdges(edges, dictionaryEdges);
        }
    }
}
