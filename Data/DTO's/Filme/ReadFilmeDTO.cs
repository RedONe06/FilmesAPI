using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO_s
{
    public class ReadFilmeDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(100, ErrorMessage = "Deve conter 100 caracteres no máximo")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "Deve estar entre 1 e 600")]
        public int ClassificacaoEtaria { get; set; }
        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
