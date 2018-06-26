using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class WO_Item
    {
        public int ID { get; set; }

        [Required]
        public int WO_HeaderID { get; set; }

        [Required]
        public int MaterialID { get; set; }

        [Required]
        public double Quantity { get; set; }


        public byte StatusID { get; set; }

        public virtual WO_Header WO_Header { get; set; }
        public virtual Material Material { get; set; }
        public virtual Status Status { get; set; }
    }
}