using System.ComponentModel.DataAnnotations;
namespace C_crudweb.Models
{
    public class ContactoModelo
    {
        
        public int IdContacto { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Correo { get; set; }
    }
}
