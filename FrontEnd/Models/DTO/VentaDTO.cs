using FrontEnd.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Models.DTO
{
    public class VentaDTO
    {
        public int CEDULA_CLIENTE { get; set; }
        public List<string> SelectedProducts { get; set; }
        public List<SelectListItem> AvailableProducts { get; set; }
        public List<int> AmauntProducts { get; set; }
        public List<Producto> ListProd { get; set; }
        public List<ItemVenta> ITEMS { get; set; }
    }

   
}