using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoLand.Models
{
    public class DealerMoto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Motorcycle> Moto { get; set; }
    }
}
