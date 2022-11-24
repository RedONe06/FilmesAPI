using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO_s.Sessao
{
    public class UpdateSessaoDTO
    {
        public int FilmeFK { get; set; }
        public int CinemaFK { get; set; }

        [Required(ErrorMessage = "O campo horário de encerramento é obrigatório")]
        public DateTime HorarioDeEncerramento { get; set; }

    }
}
