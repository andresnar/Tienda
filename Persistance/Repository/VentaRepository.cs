using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class VentaRepository
    {
        private TIENDAEntities db = new TIENDAEntities();
        public VENTA AddVenta(VENTA venta)
        {
            try
            {
                db.VENTA.Add(venta);
                db.SaveChanges();
                return venta;
            }
            catch
            {
                return null;
            }
        }

        public VENTA getVentaLastID()
        {
            try
            {
                VENTA venta = db.VENTA.ToList().OrderByDescending(x=>x.ID).FirstOrDefault();
                return venta;
            }
            catch
            {
                return null;
            }
        }
        public VENTA DeleteVenta(VENTA venta)
        {
            try
            {
                db.VENTA.Remove(venta);
                db.SaveChanges();
                return venta;
            }
            catch
            {
                return null;
            }

        }
    }
}
