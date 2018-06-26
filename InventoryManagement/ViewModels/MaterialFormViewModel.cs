using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class MaterialFormViewModel
    {
        public Material Material { get; set; }
        public IEnumerable<MaterialType> MaterialTypes { get; set; }
    }
}