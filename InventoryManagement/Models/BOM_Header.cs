using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class BOM_Header
    {
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }
        
        public virtual ICollection<BOM_Item> BOM_Items { get; set; }

        public virtual Material Product { get; set; }


    }
}