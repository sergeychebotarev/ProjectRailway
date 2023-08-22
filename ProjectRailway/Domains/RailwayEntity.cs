using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRailway.Domains
{
    public abstract class RailwayEntity
    {
        public override string ToString() => Name;

        public string Name { get; set; }
    }
}
