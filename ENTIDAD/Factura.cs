using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class FacturaDto
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public int Valor { get; set; }
        public string ValorLetras { get; set; }
        
        public string Estado { get; set; }
        public int IdCliente { get; set; }
    }
}
