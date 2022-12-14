using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
