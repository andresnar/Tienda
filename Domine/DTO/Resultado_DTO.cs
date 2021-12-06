using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.DTO
{
    public class Resultado_DTO
    {
        public bool ESTADO { get; set; }
        public string MENSAJE { get; set; }

        public Resultado_DTO(bool est, string mens)
        {
            this.ESTADO = est;
            this.MENSAJE = mens;
        }
    }
}
