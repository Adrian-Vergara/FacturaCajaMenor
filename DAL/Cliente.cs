using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cliente
    {
        public Cliente() {
            this.Facturas = new HashSet<Factura>();
        }
        [Key]
        public int IdCliente { get; set; }

        [Index(IsUnique=true)]
        public int Cedula { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        [StringLength(20)]
        public string Tipo { get; set; }
        [StringLength(10)]
        public string Estado { get; set; }
        [NotMapped]
        public int TotalFacturas { get { return Facturas.Count(); } }
        public virtual ICollection<Factura> Facturas { get; set; }  //se pone para consultar todas las facturas de un cliente
    }
}
