using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class MaterialType
    {
        public byte ID { get; set; }
        public string Type { get; set; }


        // Using for selection list
        public string DisplayType
        {
            get
            {
                return ID + ". " + Type;
            }
        }

        public static readonly byte RawMaterial = 1;
        public static readonly byte FinishedProduct = 2;
    }
}