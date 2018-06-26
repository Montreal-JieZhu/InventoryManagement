using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Status
    {
        public byte ID { get; set; }
        public string Name { get; set; }

        // Using for selection list
        public string DisplayName
        {
            get
            {
                return ID + ". " + Name;
            }
        }

        public static readonly byte NotStart = 1;
        public static readonly byte InProcessing = 2;
        public static readonly byte Completed = 3;
    }
}