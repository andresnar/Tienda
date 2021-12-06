using Domine.DTO;
using Persistance;
using Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VentaService
    {
        public Venta_DTO makeSell(Venta_DTO ventaDTO)
        {
            VentaRepository ventaRepo = new VentaRepository();
            VentaProductoRepository ventaProdRepo = new VentaProductoRepository();
            VENTA ventaBD = new VENTA() { CEDULA_CLIENTE = ventaDTO.CEDULA_CLIENTE, FECHA = ventaDTO.FECHA };
            VENTA resulVenta = ventaRepo.AddVenta(ventaBD);
            if (resulVenta != null)
            {
                ventaBD = ventaRepo.getVentaLastID();
                foreach (ItemVenta_DTO x in ventaDTO.ITEMS)
                {
                    VENTA_PRODUCTO temp = new VENTA_PRODUCTO();
                    temp.ID_PRODUCTO = x.ID_PRODUCTO;
                    temp.ID_VENTA = ventaBD.ID;
                    temp.CANTIDAD_PRODUCTO = x.CANTIDAD_PRODUCTO;
                    VENTA_PRODUCTO res = ventaProdRepo.AddVentaProducto(temp);
                    if (res == null)
                    {
                        ventaRepo.DeleteVenta(resulVenta);
                        return null;
                    }
                }
                return ventaDTO;
            }
            else
                return null;

        }
    }
}
