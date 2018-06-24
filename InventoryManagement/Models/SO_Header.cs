using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class SO_Header
    {
        public int ID { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public double? TotalAmount { get; set; }

        public virtual ICollection<SO_Item> SO_Items { get; set; }
    }
}