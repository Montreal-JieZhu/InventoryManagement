using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class WorkOrderViewModel
    {
        public WO_Header WO_Header { get; set; }
        public List<WO_Item> WO_Items { get; set; }
        public List<Status> Status { get; set; }
        public List<Material> Products { get; set; }
        public List<Material> RawMaterials { get; set; }

    }
}