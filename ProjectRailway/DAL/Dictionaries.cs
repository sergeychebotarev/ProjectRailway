using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRailway.Domains;

namespace ProjectRailway.DAL
{
    public class DictionaryPoints : Dictionary<string, RailwayPoint>
    {
    }

    public class DictionaryEdges : Dictionary<string, RailwayEdge>
    {
    }

    public class DictionaryPaths : Dictionary<string, RailwayPath>
    {
    }
}
