using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Material
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public double Quantity { get; set; }

        [Required]
        [Range(0, 100000)]
        public double Price { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

    }
}