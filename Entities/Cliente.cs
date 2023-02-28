using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Cliente : Persona
    {
        [Key]
        public int clienteId { get; set; }
        [Required]
        [PasswordPropertyTextAttribute]
        [StringLength(50)]
        public string contrasena { get; set; }
        [Required]
        public bool estado { get; set; }
        public List<Cuenta> cuentas { get; set; }



    }
}