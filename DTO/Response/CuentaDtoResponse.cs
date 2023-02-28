using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class CuentaDtoResponse
    {
        public int cuentaId { get; set; }

        public int numeroCuenta { get; set; }

        public string tipoCuenta { get; set; }

        public double saldoInicial { get; set; }

        public bool estado { get; set; }

        public int clienteId { get; set; }

        public string nombreCliente { get; set; }

        public int identificacionCliente { get; set; }

        public double saldoActual { get; set; }

    }
}
