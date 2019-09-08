using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchTracker.Models
{
    public class MyCaps
    {
        public int Id { get; set; }

        [Display(Name = "Cap Name")]
        public string CapName { get; set; }

        [Display(Name = "Cap Price")]
        public string CapPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
