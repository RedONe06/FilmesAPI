using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório")]
        public int Numero { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
