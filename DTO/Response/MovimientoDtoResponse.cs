using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class MovimientoDtoResponse
    {
        public int movimientoId { get; set; }
        public DateTime fecha { get; set; }
        public string tipoMovimiento { get; set; }
        public double valor { get; set; }
        public double saldo { get; set; }
        public int cuentaID { get; set; }
        public int numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public int clienteId { get; set; }
        public string nombreCliente { get; set; }
    }
}
