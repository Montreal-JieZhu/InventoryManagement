using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class BOM_Item
    {
        public int ID { get; set; }

        [Required]
        public int BOM_HeaderID { get; set; }

        [Required] 
        public int MaterialID { get; set; }

        [Required]
        public double Quantity { get; set; }

        public virtual BOM_Header BOM_Header { get; set; }
        public virtual Material Material { get; set; }
    }
}