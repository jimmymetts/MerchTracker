using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchTracker.Models
{
    public class MyCaps
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cap Name")]
        public string CapName { get; set; }

        [Display(Name = "Cap Price")]
        public double CapPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        //[Required]
        //public ApplicationUser User { get; set; }

        //[Required]
        //public string UserId { get; set; }

        //public virtual ICollection<MyCaps> MyCap { get; set; }
    }
}
