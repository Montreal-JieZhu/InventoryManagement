using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class StockPosting_Header
    {
        public int ID { get; set; }

        [Required]
        public int ReferenceOrderID { get; set; }

        public DateTime? DateCreated { get; set; }

        [Required]
        [StringLength(5)]
        public string Type { get; set; }

        public virtual ICollection<StockPosting_Item> StockPosting_Items { get; set; }
    }
}