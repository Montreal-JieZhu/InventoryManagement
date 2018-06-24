using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class PO_Header
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Supplier { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public double? TotalAmount { get; set; } 

        public virtual ICollection<PO_Item> PO_Items { get; set; }
    }
}