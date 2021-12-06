using FrontEnd.Models.Entities;
using System.Collections.Generic;

namespace FrontEnd.Models.BusinessLogic
{
    public class ClienteLogic
    {
        public List<Cliente> GetClients(out int statusCode, out string respuesta)
        {
            Requests<Cliente, List<Cliente>> model = new Requests<Cliente, List<Cliente>>();
            string url = "Http://localhost:51564/api/CLiente/getClients";
            List<Cliente> listado = new List<Cliente>();
            Cliente cliente = new Cliente();
            listado = model.EjecutarPeticionGET(url, listado, out statusCode, out respuesta);
            return listado;
        }

        public Cliente GetClientByID(Cliente cliente, out int statusCode, out string respuesta)
        {
            Requests<Cliente, Cliente> model = new Requests<Cliente, Cliente>();
            string url = "Http://localhost:51564/api/CLiente/getClientById?CEDULA="+cliente.CEDULA.ToString();
            Cliente clienteOut = new Cliente();
            clienteOut = model.EjecutarPeticionGET(url, clienteOut, out statusCode, out respuesta);
            return clienteOut;
        }
        public Cliente AddCLient(Cliente cliente, out int statusCode, out string respuesta)
        {
            Requests<Cliente, Cliente> model = new Requests<Cliente, Cliente>();
            string url = "http://localhost:51564/api/CLiente/AddCLient";
            Cliente clienteOut = new Cliente();
            clienteOut = model.EjecutarPeticionPOST(url, cliente, clienteOut, out statusCode, out respuesta);
            return clienteOut;
        }
        public Cliente PutClient(Cliente cliente, out int statusCode, out string respuesta)
        {
            Requests<Cliente, Cliente> model = new Requests<Cliente, Cliente>();
            string url = "http://localhost:51564/api/CLiente/PutClient";
            Cliente clienteOut = new Cliente();
            clienteOut = model.EjecutarPeticionPUT(url, cliente, clienteOut, out statusCode, out respuesta);
            return clienteOut;
        }
    }
}