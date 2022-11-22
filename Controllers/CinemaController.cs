using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _appDbContext;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas = _appDbContext.Cinemas.ToList();
            if(cinemas == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema
                                            in cinemas 
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme) 
                                            select cinema;
                cinemas = query.ToList();
            }
            List<ReadCinemaDTO> readDTO = _mapper.Map<List<ReadCinemaDTO>>(cinemas);
            return Ok(readDTO);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _appDbContext.Cinemas.Add(cinema);
            _appDbContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = BuscarNoBancoPorId(id);
            if(cinema == null)
            {
                return NotFound();
            }
            ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDTO);
        }

        

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            Cinema cinema = BuscarNoBancoPorId(id);

            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDTO, cinema);
            _appDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = BuscarNoBancoPorId(id);
            if (cinema == null)
            {
                return NotFound();
            }
            _appDbContext.Cinemas.Remove(cinema);
            _appDbContext.SaveChanges();
            return NoContent();
        }
        private Cinema BuscarNoBancoPorId(int id)
        {
            return _appDbContext.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        }
    }
}
