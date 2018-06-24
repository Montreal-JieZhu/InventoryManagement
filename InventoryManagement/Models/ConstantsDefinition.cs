using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public static class ConstantsDefinition
    {
        /* To Simplify the design, create constants instead of
         * creating new tables with key + value pair 
         * Sample:  1 - Not Start
         *          2 - Partial Completed
         *          3 - Completed 
         */


        public const string GoodReceipt = "GR";
        public const string GoodIssue = "GR";

        public const string RawMaterial = "Raw Material";
        public const string FinshedProduct = "Finished Product";

        public const string Completed = "Completed";
        public const string NotStart = "Not Start";
        public const string PartialCompleted = "Partial Completed";
    }
}