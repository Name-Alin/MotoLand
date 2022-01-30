using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoLand.Models
{
    public class MotoData
    {
        public IEnumerable<Motorcycle> Moto { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MotoCategory> MotoCategories { get; set; }
    }
}
