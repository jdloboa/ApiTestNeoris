using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Cuenta
    {
        [Key]
        public int cuentaId { get; set; }
        [Required]
        public int numeroCuenta { get; set; }
        [Required]
        [StringLength(50)]
        public string tipoCuenta { get; set; }
        [Required]
        public double saldoInicial { get; set; }
        [Required]
        public double saldoActual { get; set; }
        [Required]
        public bool estado { get; set; }
        public List<Movimiento> movimientos { get; set; }
        [Required]
        [ForeignKey("clienteId")]
        public int clienteId { get; set; }
        public Cliente cliente { get; set; }
    }
}
