using Domine.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Tienda.Controllers
{
    public class VentaController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(Producto_DTO))]
        public IHttpActionResult makeSell(JObject objeto)
        {
            if(objeto.Count > 0)
            {
                Venta_DTO ventaDTO = JsonConvert.DeserializeObject<Venta_DTO>(objeto.ToString());
                Validator<Venta_DTO> validator = new Validator<Venta_DTO>();
                bool test = validator.ValidateObject(ventaDTO);
                if (!test)
                {
                    return Content(HttpStatusCode.BadRequest, "Trama errada o incompleta");
                }                
                VentaService Vservice = new VentaService();
                Venta_DTO res = Vservice.makeSell(ventaDTO);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Error de inserción");
                }                
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Consulta Errada");
            }
        }
    }
}