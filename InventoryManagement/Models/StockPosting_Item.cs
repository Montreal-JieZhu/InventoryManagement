using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class StockPosting_Item
    {
        public int ID { get; set; }

        [Required]
        public int StockPosting_HeaderID { get; set; }

        [Required]
        public int MaterialID { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Quantity { get; set; }

        public virtual StockPosting_Header StockPosting_Header { get; set; }
        public virtual Material Material { get; set; }
    }
}