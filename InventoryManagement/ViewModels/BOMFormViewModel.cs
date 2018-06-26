using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class BOMFormViewModel
    {
        public BOM_Header BOM_Header { get; set; }
        public List<BOM_Item> BOM_Items { get; set; }
        public List<Material> Products { get; set; }
        public List<Material> RawMaterials { get; set; }

    }
}