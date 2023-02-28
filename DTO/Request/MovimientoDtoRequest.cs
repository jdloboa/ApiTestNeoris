using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class MovimientoDtoRequest
    {
        public int movimientoId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        [Required]
        public string tipoMovimiento { get; set; }
        [Required]
        public double valor { get; set; }
        [Required] 
        public double saldo { get; set; }

        public int cuentaID { get; set; }
    }
}
