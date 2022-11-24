using FilmesAPI.Models;

namespace FilmesAPI.Data.DTO_s.Sessao
{
    public class ReadSessaoDTO
    {
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public int Id { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
