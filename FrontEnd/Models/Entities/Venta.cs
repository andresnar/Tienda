using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models.Entities
{
    public class Venta
    {
        public int CEDULA_CLIENTE { get; set; }
        public DateTime FECHA { get; set; }
        public List<ItemVenta> ITEMS { get; set; }

    }
}