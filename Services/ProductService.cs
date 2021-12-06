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
    public class ProductService
    {
        public List<Producto_DTO> getProducts()
        {
            ProductRepository proRepo = new ProductRepository();
            List<PRODUCTO> BDList = proRepo.getProducts();
            List<Producto_DTO> ListDTO = new List<Producto_DTO>();
            Mapper<PRODUCTO, Producto_DTO> map = new Mapper<PRODUCTO, Producto_DTO>();
            if (BDList.Count > 0)
            {
                foreach (PRODUCTO cl in BDList)
                {
                    Producto_DTO temp = map.Mapear(cl, new Producto_DTO());
                    ListDTO.Add(temp);
                }
                return ListDTO;
            }
            return null;
        }

        public Producto_DTO getProductById(int id)
        {
            ProductRepository cliRepo = new ProductRepository();
            PRODUCTO BDClient = cliRepo.getProductById(id);
            if (BDClient != null)
            {
                Producto_DTO ProductoDTO = new Producto_DTO();
                Mapper<PRODUCTO, Producto_DTO> map = new Mapper<PRODUCTO, Producto_DTO>();
                ProductoDTO = map.Mapear(BDClient, ProductoDTO);
                return ProductoDTO;
            }
            return null;
        }

        public Producto_DTO AddProduct(Producto_DTO producto)
        {
            Producto_DTO result = new Producto_DTO();
            PRODUCTO BDClient = new PRODUCTO();
            ProductRepository prodRepo = new ProductRepository();
            Mapper<Producto_DTO, PRODUCTO> map = new Mapper<Producto_DTO, PRODUCTO>();
            BDClient = prodRepo.AddProduct(map.Mapear(producto, BDClient));
            if (BDClient != null)
            {
                return producto;
            }
            return null;
        }

        public Producto_DTO PutProduct(Producto_DTO productoDTO)
        {
            Producto_DTO result = new Producto_DTO();
            PRODUCTO BDProduct = new PRODUCTO();
            ProductRepository prodRepo = new ProductRepository();
            Mapper<Producto_DTO, PRODUCTO> map = new Mapper<Producto_DTO, PRODUCTO>();
            BDProduct = prodRepo.PutProduct(map.Mapear(productoDTO, BDProduct));
            if (BDProduct != null)
            {
                return productoDTO;
            }
            return null;
        }

        public Producto_DTO DeleteProduct(Producto_DTO productoDTO)
        {
            Producto_DTO result = new Producto_DTO();
            PRODUCTO BDProd = new PRODUCTO();
            ProductRepository prodRepo = new ProductRepository();
            Mapper<Producto_DTO, PRODUCTO> map = new Mapper<Producto_DTO, PRODUCTO>();
            BDProd = prodRepo.DeleteProduct(map.Mapear(productoDTO, BDProd));
            if (BDProd != null)
            {
                return productoDTO;
            }
            return null;
        }
    }
}
