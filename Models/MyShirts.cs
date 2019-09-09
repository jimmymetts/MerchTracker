using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchTracker.Models
{
    public class MyShirts
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Shirt Name")]
        public string ShirtName { get; set; }

        [Display(Name = "Shirt Price")]
        public double ShirtPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        //[Required]
        //public ApplicationUser  User{ get; set; }

        //[Required]
        //public string UserId { get; set; }

        //public virtual ICollection<MyShirts> MyShirt { get; set; }


    }
}
