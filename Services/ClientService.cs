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
    public class ClientService
    {
        public List<Cliente_DTO> getClients()
        {
            ClientRepository cliRepo = new ClientRepository();
            List<CLIENTE> BDList = cliRepo.getClients();
            if(BDList.Count > 0)
            {
                List<Cliente_DTO> ListDTO = new List<Cliente_DTO>();
                Mapper<CLIENTE, Cliente_DTO> map = new Mapper<CLIENTE, Cliente_DTO>();                              
                foreach (CLIENTE cl in BDList)
                {
                    Cliente_DTO temp = map.Mapear(cl, new Cliente_DTO());
                    ListDTO.Add(temp);
                }
                return ListDTO;                
            }            
            return null;
        }

        public Cliente_DTO getClientById(int cedula)
        {
            ClientRepository cliRepo = new ClientRepository();
            CLIENTE BDClient = cliRepo.getClientByCedula(cedula);
            if(BDClient != null)
            {
                Cliente_DTO ClientDTO = new Cliente_DTO();
                Mapper<CLIENTE, Cliente_DTO> map = new Mapper<CLIENTE, Cliente_DTO>();
                ClientDTO = map.Mapear(BDClient, ClientDTO);
                return ClientDTO;
            }
            return null;
        }

        public Cliente_DTO AddClient(Cliente_DTO cliente)
        {
            Cliente_DTO result = new Cliente_DTO();
            CLIENTE BDClient = new CLIENTE();
            ClientRepository cliRepo = new ClientRepository();
            Mapper<Cliente_DTO, CLIENTE> map = new Mapper<Cliente_DTO, CLIENTE>();
            BDClient = cliRepo.AddClient(map.Mapear(cliente,BDClient));
            if(BDClient != null)
            {
                return cliente;
            }
            return null;
        }

        public Cliente_DTO PutClient(Cliente_DTO clienteDTO)
        {
            Cliente_DTO result = new Cliente_DTO();
            CLIENTE BDClient = new CLIENTE();
            ClientRepository cliRepo = new ClientRepository();
            Mapper<Cliente_DTO, CLIENTE> map = new Mapper<Cliente_DTO, CLIENTE>();
            BDClient = cliRepo.PutClient(map.Mapear(clienteDTO, BDClient));
            if (BDClient != null)
            {
                return clienteDTO;
            }
            return null;
        }

        public Cliente_DTO DeleteClient(Cliente_DTO clienteDTO)
        {
            Cliente_DTO result = new Cliente_DTO();
            CLIENTE BDClient = new CLIENTE();
            ClientRepository cliRepo = new ClientRepository();
            Mapper<Cliente_DTO, CLIENTE> map = new Mapper<Cliente_DTO, CLIENTE>();
            BDClient = cliRepo.DeleteClient(map.Mapear(clienteDTO, BDClient));
            if (BDClient != null)
            {
                return clienteDTO;
            }
            return null;
        }

    }
}
