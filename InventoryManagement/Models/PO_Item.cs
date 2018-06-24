using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class PO_Item
    {
        public int ID { get; set; }

        [Required]
        public int PO_HeaderID { get; set; }

        [Required]
        public int MaterialID { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Quantity { get; set; }

        [Range(0, 100000)]
        public double? Price { get; set; }

        [StringLength(30)]
        public string GRStatus { get; set; }

        public virtual PO_Header PO_Header { get; set; }
        public virtual Material Material { get; set; }
    }
}