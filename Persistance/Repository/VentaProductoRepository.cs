using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class VentaProductoRepository
    {
        private TIENDAEntities db = new TIENDAEntities();

        public VENTA_PRODUCTO AddVentaProducto(VENTA_PRODUCTO ventaProducto)
        {
            try
            {
                db.VENTA_PRODUCTO.Add(ventaProducto);
                db.SaveChanges();
                return ventaProducto;
            }
            catch
            {
                return null;
            }
        }

    }
}
