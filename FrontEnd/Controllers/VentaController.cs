using FrontEnd.Models.BusinessLogic;
using FrontEnd.Models.DTO;
using FrontEnd.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult Index()
        {
            int statusCode;
            string respuesta;

            //Listo Todos los Clientes y los convierto a DTO
            ClienteLogic modelCli = new ClienteLogic();
            List<Cliente> ListClient = modelCli.GetClients(out statusCode, out respuesta);
            List<ClienteDTO> ListDTO = new List<ClienteDTO>();
            foreach(Cliente a in ListClient)
            {
                ClienteDTO tempo = new ClienteDTO();
                tempo.CEDULA = a.CEDULA;
                tempo.NOMBRE = a.NOMBRE + " " + a.APELLIDO;
                ListDTO.Add(tempo);
            }
            ViewBag.ListClient = ListDTO;

            // Consigo un listado de todos los productos
            ProductLogic modelProd = new ProductLogic();
            VentaDTO VDto = new VentaDTO();
            VDto.ListProd = modelProd.GetProducts(out statusCode, out respuesta);

            List<SelectListItem> AvailableProducts = new List<SelectListItem>();
            foreach(Producto a in VDto.ListProd)
            {
                SelectListItem x = new SelectListItem { Text = a.ID.ToString(), Value = a.ID.ToString() };
                AvailableProducts.Add(x);
            }
            VDto.AvailableProducts = AvailableProducts;

            return View(VDto);
        }

        [HttpPost]
        public ActionResult Comprar(VentaDTO venta)
        {
            if (ModelState.IsValid)
            {
                List<ItemVenta> listadoItems = new List<ItemVenta>();
                foreach(string s in venta.SelectedProducts)
                {
                    int id = Convert.ToInt32(s);
                    int cant = venta.AmauntProducts[id-1];
                    ItemVenta tempo = new ItemVenta() { ID_PRODUCTO = id, CANTIDAD_PRODUCTO=cant };
                    listadoItems.Add(tempo);
                }
                venta.ITEMS = listadoItems;

                VentaLogic model = new VentaLogic();
                int statusCode;
                string respuesta;

                Venta DataReturn = model.MakeSell(venta, out statusCode, out respuesta);
                if (statusCode == 200)
                {
                    ProductLogic modelProd = new ProductLogic();
                    List<Producto> listProd = modelProd.GetProducts(out statusCode, out respuesta);
                    decimal valorTempo = 0;
                    int cantProd = 0;
                    foreach(ItemVenta x in venta.ITEMS)
                    {
                        valorTempo = valorTempo + ((from a in listProd
                                                   where a.ID == x.ID_PRODUCTO
                                                   select a.VALOR).Single() * x.CANTIDAD_PRODUCTO);
                        cantProd = cantProd + x.CANTIDAD_PRODUCTO;
                    }
                    string mensaje = "COMPRA REALIZADA EXITOSAMENTE. Usted ha comprado " + cantProd.ToString() + " Productos por valor de $" + valorTempo.ToString();
                    return RedirectToAction("Resultado", new { statusCode = 200, respuesta = mensaje });
                }
                return RedirectToAction("Error", new { statusCode = statusCode, respuesta = respuesta });
            }
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Resultado(int statusCode, string respuesta)
        {
            ViewBag.statusCode = statusCode;
            ViewBag.mensaje = respuesta;
            return View();
        }

        [HttpGet]
        public ActionResult Error(int statusCode, string respuesta)
        {
            ViewBag.statusCode = statusCode;
            ViewBag.mensaje = respuesta;
            return View();
        }
    }
}