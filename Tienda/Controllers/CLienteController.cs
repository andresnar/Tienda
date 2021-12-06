using Domine.DTO;
using Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Tienda.Controllers
{
    public class CLienteController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(Cliente_DTO))]
        public IHttpActionResult GetClients()
        {
            ClientService serv = new ClientService();            
            List<Cliente_DTO> listado = serv.getClients();
            if (listado.Count > 0)
            {
                return Ok(listado);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No hay elementos");
            }
            
        }

        [HttpGet]
        [ResponseType(typeof(Cliente_DTO))]
        public IHttpActionResult GetClientByID(int CEDULA)
        {
            ClientService cs = new ClientService();            
            Cliente_DTO clienteDTOOut = new Cliente_DTO();
            if (CEDULA != 0)
            {
                clienteDTOOut = cs.getClientById(CEDULA);
                if (clienteDTOOut != null)
                {
                    return Ok(clienteDTOOut);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No hay elementos");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Consulta Errada");
            }
        }

        
        [HttpPost]
        [ResponseType(typeof(Cliente_DTO))]
        public IHttpActionResult AddCLient(JObject objeto)
        {
            if(objeto.Count > 0)
            {
                Cliente_DTO clienteDTO = JsonConvert.DeserializeObject<Cliente_DTO>(objeto.ToString());
                Validator<Cliente_DTO> validator = new Validator<Cliente_DTO>();
                bool test = validator.ValidateObject(clienteDTO);
                if (!test)
                {
                    return Content(HttpStatusCode.BadRequest, "Trama errada o incompleta");
                }
                ClientService serv = new ClientService();
                Cliente_DTO clienteDTOOut = serv.AddClient(clienteDTO);
                if (clienteDTOOut != null)
                {
                    return Ok(clienteDTOOut);
                }
                else
                {
                    return InternalServerError(new Exception("Error en la grabación."));
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Consulta Errada.");
            }
        }

        [HttpPut]
        [ResponseType(typeof(Cliente_DTO))]
        public IHttpActionResult PutClient(JObject objeto)
        {
            if(objeto.Count > 0)
            {
                Cliente_DTO clienteDTO = JsonConvert.DeserializeObject<Cliente_DTO>(objeto.ToString());
                Validator<Cliente_DTO> validator = new Validator<Cliente_DTO>();
                bool test = validator.ValidateObject(clienteDTO);
                if (!test)
                {
                    return Content(HttpStatusCode.BadRequest, "Trama errada o incompleta");
                }
                ClientService serv = new ClientService();
                Cliente_DTO clienteDTOOut = serv.PutClient(clienteDTO);
                if (clienteDTOOut != null)
                {
                    return Ok(clienteDTOOut);
                }
                else
                {
                    return InternalServerError(new Exception("Error de actualizacion."));
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Consulta errada");
            }
        }
    }
}