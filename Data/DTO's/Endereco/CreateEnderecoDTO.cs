using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO_s
{
    public class CreateEnderecoDTO
    {
        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório")]
        public int Numero { get; set; }
    }
}
