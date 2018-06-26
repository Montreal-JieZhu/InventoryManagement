using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class ChooseProductViewModel
    {
        public List<Material> Products { get; set; }
        public int SelectedProductID { get; set; }
        public double Quantity { get; set; }
    }
}