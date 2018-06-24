using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class SO_Item
    {
        public int ID { get; set; }

        [Required]
        public int SO_HeaderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Quantity { get; set; }

        [Range(0, 100000)]
        public double? Price { get; set; }

        [StringLength(30)]
        public string GIStatus { get; set; }

        public virtual SO_Header SO_Header { get; set; }
        public virtual Material Product { get; set; }
    }
}