using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public int FilmeFK { get; set; }
        public int CinemaFK { get; set; }

        [Required(ErrorMessage = "O campo horário de encerramento é obrigatório")]
        public DateTime HorarioDeEncerramento { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
