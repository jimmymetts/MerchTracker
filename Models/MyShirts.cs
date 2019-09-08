using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchTracker.Models
{
    public class MyShirts
    {
        public int Id { get; set; }

        [Display(Name = "Shirt Name")]
        public string ShirtName { get; set; }

        [Display(Name = "Shirt Price")]
        public string ShirtPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
