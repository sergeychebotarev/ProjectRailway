using ProjectRailway.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.DAL
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Метод расширения для добавления точки(point) в словарь точек
        /// </summary>
        /// <param name="pointName">имя точки</param>
        public static DictionaryPoints AddPoint(this DictionaryPoints dictionaryPoint,
            string pointName, int x, int y)
        {
            dictionaryPoint.Add(pointName, new RailwayPoint(pointName, x, y));

            return dictionaryPoint;
        }

        public static void AddPointDistinct(this DictionaryPoints dictionaryPoints,
            RailwayPoint point)
        {
            if (!dictionaryPoints.ContainsKey(point.Name))
            {
                dictionaryPoints.Add(point.Name, point);
            }
        }

        public static void AddEdgeDistinct(this DictionaryEdges dictionaryEdges,
            RailwayEdge edge)
        {
            if (!dictionaryEdges.ContainsKey(edge.Name))
            {
                dictionaryEdges.Add(edge.Name, edge);
            }
        }

        /// <summary>
        /// Метод расширения для добавления участка(edge) в словарь участков
        /// </summary>
        /// <param name="dictionaryPoints">словарь точек</param>
        /// <param name="edgesNames">названия участков</param>
        public static DictionaryEdges AddEdge(this DictionaryEdges dictionaryEdges,
            DictionaryPoints dictionaryPoints, params string[] edgesNames)
        {
            foreach (var edgeName in edgesNames)
            {
                string[] pointsNames = edgeName.Split('-');
                string first = pointsNames.First();
                string last = pointsNames.Last();

                RailwayPoint p1 = dictionaryPoints[first];
                RailwayPoint p2 = dictionaryPoints[last];

                var edge1 = new RailwayEdge(p1, p2);
                dictionaryEdges.Add(edge1.Name, edge1);
                /*
                var edgeReverse = new RailwayEdge(p2, p1);
                dictionaryEdges.Add(edgeReverse.Name, edgeReverse);*/
            }

            return dictionaryEdges;
        }

        /// <summary>
        /// Метод расширения для добавления пути(path) в словарь путей
        /// </summary>
        /// <param name="dictionaryEdges">словарь путей</param>
        /// <param name="pathName">имя пути</param>
        /// <param name="edgesText">строка с участками</param>
        public static DictionaryPaths AddPath(this DictionaryPaths dictionaryPaths,
            DictionaryEdges dictionaryEdges, string pathName, string edgesText)
        {
            var edgesNames = edgesText
                .Split(';').ToList();
            var edges = edgesNames
                .Select(x => dictionaryEdges[x])
                .ToList();

            dictionaryPaths.Add(pathName, new RailwayPath(pathName, edges));

            return dictionaryPaths;
        }

    }
}
