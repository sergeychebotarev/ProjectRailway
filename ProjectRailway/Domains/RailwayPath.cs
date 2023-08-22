using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Domains
{
    /// <summary>
    /// Путь
    /// </summary>
    public class RailwayPath : RailwayEntity
    {

        public List<RailwayEdge> Edges { get; set; }

        public RailwayPath()
        { }

        public RailwayPath(string pathName, List<RailwayEdge> edges)
        {
            Name = pathName;
            Edges = edges;
        }
    }
}
