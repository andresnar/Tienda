using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class ClientRepository
    {
        private TIENDAEntities db = new TIENDAEntities();
        public List<CLIENTE> getClients()
        {
            try
            {
                return db.CLIENTE.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public CLIENTE getClientByCedula(int cedula)
        {
            try
            {
                return db.CLIENTE.Where(x => x.CEDULA == cedula).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CLIENTE AddClient(CLIENTE cliente)
        {
            try
            {
                db.CLIENTE.Add(cliente);
                db.SaveChanges();
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public CLIENTE PutClient(CLIENTE cliente)
        {
            try
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return cliente;
            }
            catch(Exception ex)
            {
                return null;
            }            
        }

        public CLIENTE DeleteClient(CLIENTE cliente)
        {
            try
            {
                db.CLIENTE.Remove(cliente);
                db.SaveChanges();
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

    }
}
