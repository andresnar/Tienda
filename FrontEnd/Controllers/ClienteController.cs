using FrontEnd.Models.BusinessLogic;
using FrontEnd.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Buscar(Cliente cliente)
        {            
            ClienteLogic model = new ClienteLogic();
            int statusCode;
            string respuesta;
            List<Cliente> DataReturn = new List<Cliente>();

            if (cliente.APELLIDO == null && cliente.NOMBRE == null && cliente.CEDULA == 0
                && cliente.ESTADO == 0 && cliente.TELEFONO == null)
            {
                DataReturn = model.GetClients(out statusCode, out respuesta);
            }
            else
            {
                if (cliente.CEDULA != 0)
                {
                    Cliente tempo = model.GetClientByID(cliente, out statusCode, out respuesta);
                    if (tempo != null)
                        DataReturn.Add(tempo);
                }
                else
                {
                    respuesta = "Debe ingresar una cedula para poder consultar";
                    statusCode = 400;
                }                
            }            
            if (statusCode == 200)
            {
                return View(DataReturn);
            }
            return RedirectToActionPermanent("Error", new { statusCode = statusCode, respuesta = respuesta });
        }

        [HttpPost]
        public ActionResult Insertar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClienteLogic model = new ClienteLogic();
                int statusCode;
                string respuesta;

                Cliente DataReturn = model.AddCLient(cliente, out statusCode, out respuesta);
                if (statusCode == 200)
                {
                    return Redirect("/Home/Index");
                }
                return RedirectToActionPermanent("Error", new { statusCode = statusCode, respuesta = respuesta });
            }
            return RedirectToActionPermanent("Index", "Cliente");
        }

        [HttpGet]
        public ActionResult Actualizar(int cedula)
        {
            ClienteLogic model = new ClienteLogic();
            Cliente cliente = new Cliente();
            cliente.CEDULA = cedula;
            int statusCode;
            string respuesta;
            Cliente resultado = model.GetClientByID(cliente, out statusCode, out respuesta);
            if(statusCode == 200)
            {
                return View(resultado);
            }
            return RedirectToActionPermanent("Error", new { statusCode = statusCode, respuesta = respuesta });
        }

        [HttpPost]
        public ActionResult Actualizar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClienteLogic model = new ClienteLogic();
                int statusCode;
                string respuesta;
                Cliente DataReturn = model.PutClient(cliente, out statusCode, out respuesta);
                if (statusCode == 200)
                {
                    return Redirect("/Home/Index");
                }
                return RedirectToActionPermanent("Error", new { statusCode = statusCode, respuesta = respuesta });
            }
            return RedirectToActionPermanent("Index", "Cliente");
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