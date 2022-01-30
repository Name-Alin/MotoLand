using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotoLand.Models
{
    public class Motorcycle
    {

        public int ID { get; set; }

        [Display(Name = "Moto brand")]
        [Required, StringLength(30, MinimumLength = 2)]
        public string brand { get; set; }

        [Required, StringLength(20, MinimumLength = 2)]
        [Display(Name = "Moto model")]
        public string model { get; set; }
        public int year { get; set; }
        public double price { get; set; }

        [ForeignKey("DealerMoto")]
        public int DealerID { get; set; }
        public DealerMoto DealerMoto { get; set; }
        public ICollection<MotoCategory> MotoCategories { get; set; }

    }
}
