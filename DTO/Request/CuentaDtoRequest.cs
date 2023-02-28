using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class CuentaDtoRequest
    {
        public int cuentaId { get; set; }
        [Required]
        public int numeroCuenta { get; set; }
        [Required]
        public string tipoCuenta { get; set; }
        [Required]
        public double saldoInicial { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public int clienteId { get; set; }

    }
}
