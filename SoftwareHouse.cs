using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class SoftwareHouse
    {
        public long Id { get; set;  }
        public string Name { get; set; }

        public List<Videogame> games { get; set; }
    }
}
