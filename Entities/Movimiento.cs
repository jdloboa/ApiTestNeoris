using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Movimiento
    {
        [Key]
        public int movimientoId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        [Required]
        [StringLength(50)]
        public string tipoMovimiento { get; set; }
        [Required]
        public double valor { get; set; }
        [Required]
        [ForeignKey("cuentaID")]
        public int cuentaID { get; set; }
        public Cuenta cuenta { get; set; }
    }
}
