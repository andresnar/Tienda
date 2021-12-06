using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.DTO
{
    public class Venta_DTO
    {
        public int CEDULA_CLIENTE { get; set; }
        public DateTime FECHA { get; set; }
        public List<ItemVenta_DTO> ITEMS { get; set; }
    }
}
