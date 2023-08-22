using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Domains
{
    /// <summary>
    /// Парк
    /// </summary>
    public class RailwayPark : RailwayEntity
    {

        public List<RailwayPath> Paths { get; set; }

        public RailwayPark()
        {
            Paths = new List<RailwayPath>();
        }

        public RailwayPark(string parkName, params RailwayPath[] paths) : this()
        {
            this.Name = parkName;
            Paths.AddRange(paths);
        }
    }
}
