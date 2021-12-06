using FrontEnd.Models.DTO;
using FrontEnd.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models.BusinessLogic
{
    public class VentaLogic
    {
        public Venta MakeSell(VentaDTO objeto, out int statusCode, out string respuesta)
        {
            Venta venta = new Venta();
            venta.CEDULA_CLIENTE = objeto.CEDULA_CLIENTE;
            venta.FECHA = DateTime.Now;
            //List<ItemVenta> Listado = new List<ItemVenta>();
            //Listado.Add(new ItemVenta() { ID_PRODUCTO = objeto.ID_PRODUCTO, CANTIDAD_PRODUCTO = objeto.CANTIDAD_PRODUCTO });
            venta.ITEMS = objeto.ITEMS;

            Requests<Venta, Venta> model = new Requests<Venta, Venta>();
            string url = "http://localhost:51564/api/Venta/MakeSell";
            Venta ventaOut = new Venta();
            ventaOut = model.EjecutarPeticionPOST(url, venta, ventaOut, out statusCode, out respuesta);
            return ventaOut;
        }
    }
}