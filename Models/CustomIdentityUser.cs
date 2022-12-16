using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Utilities.IO.Pem;

namespace UsuariosAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
