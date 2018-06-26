using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class StockPostingViewModel
    {
        public StockPosting_Header StockPosting_Header { get; set; }
        public List<StockPosting_Item> StockPosting_Items { get; set; }

        public List<Material> Products { get; set; }
        public List<Material> RawMaterials { get; set; }
        public List<PostingType> PostingTypes { get; set; }
    }
}