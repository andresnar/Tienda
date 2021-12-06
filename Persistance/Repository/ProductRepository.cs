using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class ProductRepository
    {
        private TIENDAEntities db = new TIENDAEntities();
        public List<PRODUCTO> getProducts()
        {
            try
            {
                return db.PRODUCTO.ToList();
            }
            catch
            {
                return null;
            }
            
        }
        public PRODUCTO getProductById(int id)
        {
            try
            {
                return db.PRODUCTO.Where(x => x.ID == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            
        }
        public PRODUCTO AddProduct(PRODUCTO prod)
        {
            try
            {
                db.PRODUCTO.Add(prod);
                db.SaveChanges();
                return prod;
            }
            catch
            {
                return null;
            }
            
        }
        public PRODUCTO PutProduct(PRODUCTO prod)
        {
            try
            {
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return prod;
            }
            catch
            {
                return null;
            }
            
        }

        public PRODUCTO DeleteProduct(PRODUCTO prod)
        {
            try
            {
                db.PRODUCTO.Remove(prod);
                db.SaveChanges();
                return prod;
            }
            catch
            {
                return null;
            }
            
        }

    }
}
