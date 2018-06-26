using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class PostingType
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

        public static readonly byte GoodReceipt_PurchaseOrder = 1;
        public static readonly byte GoodIssue_WorkOrder = 2;
        public static readonly byte GoodReceipt_WorkOrder = 3;
        public static readonly byte GoodIssue_SalesOrder = 4;
    }
}