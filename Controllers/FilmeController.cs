using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FilmeController
    {
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public void AdicionarFilme([FromBody]Filme filme)
        {
            filmes.Add(filme);
        }
    }
}
