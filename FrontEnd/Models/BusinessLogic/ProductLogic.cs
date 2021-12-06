using FrontEnd.Models.Entities;
using System.Collections.Generic;

namespace FrontEnd.Models.BusinessLogic
{
    public class ProductLogic
    {
        public List<Producto> GetProducts(out int statusCode, out string respuesta)
        {
            Requests<Producto, List<Producto>> model = new Requests<Producto, List<Producto>>();
            string url = "http://localhost:51564/api/Producto/GetProducts";
            List<Producto> listado = new List<Producto>();
            Producto Producto = new Producto();
            listado = model.EjecutarPeticionGET(url, listado, out statusCode, out respuesta);
            return listado;
        }

        public Producto getProductoByID(Producto Producto, out int statusCode, out string respuesta)
        {
            Requests<Producto, Producto> model = new Requests<Producto, Producto>();
            string url = "Http://localhost:51564/api/Producto/GetProductById?idProducto=" + Producto.ID.ToString();
            Producto ProductoOut = new Producto();
            ProductoOut = model.EjecutarPeticionGET(url, ProductoOut, out statusCode, out respuesta);
            return ProductoOut;
        }
        public Producto AddProduct(Producto Producto, out int statusCode, out string respuesta)
        {
            Requests<Producto, Producto> model = new Requests<Producto, Producto>();
            string url = "http://localhost:51564/api/Producto/AddProduct";
            Producto ProductoOut = new Producto();
            ProductoOut = model.EjecutarPeticionPOST(url, Producto, ProductoOut, out statusCode, out respuesta);
            return ProductoOut;
        }
        public Producto PutProduct(Producto Producto, out int statusCode, out string respuesta)
        {
            Requests<Producto, Producto> model = new Requests<Producto, Producto>();
            string url = "http://localhost:51564/api/Producto/PutProduct";
            Producto ProductoOut = new Producto();
            ProductoOut = model.EjecutarPeticionPUT(url, Producto, ProductoOut, out statusCode, out respuesta);
            return ProductoOut;
        }
    }
}