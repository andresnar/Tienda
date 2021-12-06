using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.DTO
{
    public class Producto_DTO
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public decimal VALOR { get; set; }
        public int ESTADO { get; set; }

        public Producto_DTO(int? ID, string nomb, decimal valor, int estado = 1)
        {
            this.ID = ID ?? 0;
            this.NOMBRE = nomb;
            this.VALOR = valor;
            this.ESTADO = estado;
        }

        public Producto_DTO()
        {

        }
    }
}
