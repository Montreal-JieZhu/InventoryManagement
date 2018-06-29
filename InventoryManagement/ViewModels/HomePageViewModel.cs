using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class HomePageViewModel
    {
        public double MaterialQuantity { get; set; }
        public double WorkOrderQuantity { get; set; }
        public List<WO_Header> WOList { get; set; }
    }
}