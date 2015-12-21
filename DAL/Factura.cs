using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Factura
    {

        [Key]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public int Valor { get; set; }
        [StringLength(100)]
        public string ValorLetras { get; set; }
        
        [StringLength(10)]
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente {get; set;} //Para establecer la relación de una factura con el Cliente
        
    }
}
