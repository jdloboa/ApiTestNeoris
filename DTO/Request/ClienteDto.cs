using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class ClienteDto
    {
        public int clienteId { get; set; }
        [Required]
        public int identificacion { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string contrasena { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public string genero { get; set; }
        [Required]
        public int edad { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public long telefono { get; set; }
    }
}
