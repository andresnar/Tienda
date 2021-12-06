using FrontEnd.Models.BusinessLogic;
using FrontEnd.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(Producto producto)
        {
            ProductLogic model = new ProductLogic();
            int statusCode;
            string respuesta;
            List<Producto> DataReturn = new List<Producto>();

            if (producto.ID == 0 && producto.NOMBRE == null && producto.VALOR == 0
                && producto.ESTADO == 0)
            {
                DataReturn = model.GetProducts(out statusCode, out respuesta);
            }
            else
            {
                if(producto.ID != 0)
                {
                    Producto tempo = model.getProductoByID(producto, out statusCode, out respuesta);
                    if (tempo != null)
                        DataReturn.Add(tempo);
                }
                else
                {
                    respuesta = "Debe ingresar una ID para poder consultar";
                    statusCode = 400;
                }
            }
            if (statusCode == 200)
            {
                return View(DataReturn);
            }
            return RedirectToAction("Error", new { statusCode = statusCode, respuesta = respuesta });
        }

        [HttpPost]
        public ActionResult Insertar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductLogic model = new ProductLogic();
                int statusCode;
                string respuesta;

                Producto DataReturn = model.AddProduct(producto, out statusCode, out respuesta);
                if (statusCode == 200)
                {
                    return Redirect("/Producto/Index");
                    //return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Error", new { statusCode = statusCode, respuesta = respuesta });
            }
            return RedirectToAction("Index", "Producto");
        }

        [HttpGet]
        public ActionResult Actualizar(int idProducto)
        {
            ProductLogic model = new ProductLogic();
            Producto prod = new Producto();
            prod.ID = idProducto;
            int statusCode;
            string respuesta;
            Producto resultado = model.getProductoByID(prod, out statusCode, out respuesta);
            if (statusCode == 200)
            {
                return View(resultado);
            }
            return RedirectToActionPermanent("Error", new { statusCode = statusCode, respuesta = respuesta });
        }

        [HttpPost]
        public ActionResult Actualizar(Producto prod)
        {
            if (ModelState.IsValid)
            {
                ProductLogic model = new ProductLogic();
                int statusCode;
                string respuesta;
                Producto DataReturn = model.PutProduct(prod, out statusCode, out respuesta);
                if (statusCode == 200)
                {
                    return Redirect("/Home/Index");
                }
                return RedirectToActionPermanent("Error", new { statusCode = statusCode, respuesta = respuesta });
            }
            return RedirectToActionPermanent("Index", "Producto");
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