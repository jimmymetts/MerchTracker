using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchTracker.Models
{
    public class MyAccessories
    {
        public int Id { get; set; }

        [Display(Name = "Accessory Name")]
        public string AccessoryName { get; set; }

        [Display(Name = "Accessory Price")]
        public double AccessoryPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
