using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Domains
{
    public class RailwayStation : RailwayEntity
    {
        public List<RailwayPark> Parks { get; set; }

        public RailwayStation()
        {
            Parks = new List<RailwayPark>();
        }

        public RailwayStation(string stationName) : this()
        {
            Name = stationName;
        }
    }
}
