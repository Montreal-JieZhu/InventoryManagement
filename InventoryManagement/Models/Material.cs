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
        [StringLength(40)]
        public string MaterialCode { get; set; }

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
        public byte MaterialTypeID { get; set; }

        public virtual MaterialType MaterialType { get; set; }


        public string DisplayName
        {
            get
            {
                return MaterialCode + " - " + Name; 
            }
        }
    }
}