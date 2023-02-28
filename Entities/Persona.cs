using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Persona
    {
        public int personaId { get; set; }
   
        public string nombre { get; set; }
    
        public string genero { get; set; }
        public int edad { get; set; }
 
        public string direccion { get; set; }

        public long telefono { get; set; }
    }
}
