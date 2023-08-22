using ProjectRailway.DAL;
using ProjectRailway.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Abstract
{
    public interface IDataLoader
    {
        DictionaryPoints GetPoints();

        DictionaryEdges GetEdges(DictionaryPoints points);

        DictionaryPaths GetPaths(DictionaryEdges edges);

        List<RailwayPark> GetParks(DictionaryPaths path);
    }
}
