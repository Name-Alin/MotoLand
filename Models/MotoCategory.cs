using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoLand.Models
{
    public class MotoCategory
    {
        public int ID { get; set; }
        public int MotoID { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
