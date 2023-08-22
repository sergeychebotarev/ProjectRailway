using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Domains
{
    /// <summary>
    /// Отрезок пути
    /// </summary>
    public class RailwayEdge : RailwayEntity
    {
        public IEnumerable<RailwayPoint> EnumeratePoints()
        {
            yield return PointStart;

            yield return PointEnd;
        }

        public RailwayPoint PointStart{ get; set; }

        public RailwayPoint PointEnd { get; set; }

        public double Length { get; set; }

        public RailwayEdge()
        { }

        public RailwayEdge(RailwayPoint p1, RailwayPoint p2)
        {
            PointStart = p1;
            PointEnd = p2;
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            Length = Math.Sqrt(dx * dx + dy * dy);
            Name = $"{PointStart.Name}-{PointEnd.Name}";
        }

        public override string ToString() => Name;
    }
}
