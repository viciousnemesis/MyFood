using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Models
{
    public class Food
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Range(1, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal ServingSize { get; set; }

        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Carb { get; set; }

        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Protein { get; set; }

        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Fat { get; set; }



    }

}
