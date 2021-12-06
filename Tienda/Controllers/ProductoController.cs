using Domine.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Tienda.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(Producto_DTO))]
        public IHttpActionResult GetProducts()
        {
            ProductService serv = new ProductService();            
            List<Producto_DTO> listado = serv.getProducts();
            if (listado != null)
            {
                return Ok(listado);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No hay elementos");
            }
        }

        [HttpGet]
        [ResponseType(typeof(Producto_DTO))]
        public IHttpActionResult GetProductById(int idProducto)
        {           
            ProductService serv = new ProductService();
            Producto_DTO productoDTOOut = new Producto_DTO();
            if(idProducto !=0)
            {
                productoDTOOut = serv.getProductById(idProducto);
                if(productoDTOOut != null)
                {
                    return Ok(productoDTOOut);
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
        [ResponseType(typeof(Producto_DTO))]
        public IHttpActionResult AddProduct(JObject objeto)
        {
            if(objeto.Count > 0)
            {
                Producto_DTO productoDTO = JsonConvert.DeserializeObject<Producto_DTO>(objeto.ToString());
                Validator<Producto_DTO> validator = new Validator<Producto_DTO>();
                bool test = validator.ValidateObject(productoDTO);
                if (!test)
                {
                    return Content(HttpStatusCode.BadRequest, "Trama errada o incompleta");
                }
                ProductService serv = new ProductService();
                Producto_DTO productoDTOOut = serv.AddProduct(productoDTO);
                if (productoDTOOut != null)
                {
                    return Ok(productoDTOOut);
                }
                else
                {
                    return InternalServerError(new Exception("Error en la inserción."));
                }                
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Consulta Errada");
            }
        }

        [HttpPut]
        [ResponseType(typeof(Producto_DTO))]
        public IHttpActionResult PutProduct(JObject objeto)
        {
            if(objeto.Count > 0)
            {
                Producto_DTO productoDTO = JsonConvert.DeserializeObject<Producto_DTO>(objeto.ToString());
                Validator<Producto_DTO> validator = new Validator<Producto_DTO>();
                bool test = validator.ValidateObject(productoDTO);
                if (!test)
                {
                    return Content(HttpStatusCode.BadRequest, "Trama errada o incompleta");
                }                
                ProductService serv = new ProductService();
                Producto_DTO res = serv.PutProduct(productoDTO);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return InternalServerError(new Exception("Error en la actualización."));
                }                
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Consulta Errada");
            }
            
        }
    }
}