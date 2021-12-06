using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models.Entities
{
    public class Producto
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public decimal VALOR { get; set; }
        public int ESTADO { get; set; }

        public Producto(int? ID, string nomb, decimal valor, int estado = 1)
        {
            this.ID = ID ?? 0;
            this.NOMBRE = nomb;
            this.VALOR = valor;
            this.ESTADO = estado;
        }

        public Producto()
        {

        }
    }
}