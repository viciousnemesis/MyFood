using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Models
{
    public class Food
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Name { get; set; }
        public decimal Carb { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal ServingSize { get; set; }

    }

}
