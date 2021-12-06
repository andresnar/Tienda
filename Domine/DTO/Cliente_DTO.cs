using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.DTO
{
    public class Cliente_DTO
    {
        public int CEDULA { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string TELEFONO { get; set; }
        public int ESTADO { get; set; }

        public Cliente_DTO(int ced, string nom, string apell, string tel, int estado)
        {
            this.CEDULA = ced;
            this.NOMBRE = nom;
            this.APELLIDO = apell;
            this.TELEFONO = tel;
            this.ESTADO = estado;
        }
        public Cliente_DTO()
        {

        }
    }
}
