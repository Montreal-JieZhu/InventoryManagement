using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class WO_Header
    {
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [StringLength(30)]
        public string GRStatus { get; set;}

        public ICollection<WO_Item> WO_Items { get; set; }
        public Material Product { get; set; }

    }
}