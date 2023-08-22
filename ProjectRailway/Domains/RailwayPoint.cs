using MIConvexHull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Domains
{
    /// <summary>
    /// Точка пути
    /// </summary>
    public class RailwayPoint : RailwayEntity, IVertex2D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public RailwayPoint()
        { }

        public RailwayPoint(string name, double x, double y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
