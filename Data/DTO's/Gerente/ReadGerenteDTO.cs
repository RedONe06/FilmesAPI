using FilmesAPI.Models;

namespace FilmesAPI.Data.DTO_s.Gerente
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
