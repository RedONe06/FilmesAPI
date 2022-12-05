using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace UsuariosAPI.Data.DTOs.Usuario
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        public string RePassword { get; set; }
    }
}
