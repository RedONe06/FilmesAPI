using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Data.DTO_s.Gerente;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.Gerente.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = gerente.Id }, gerente);

        }

        [HttpGet("{id}")]
        public object RecuperarGerentePorId(int id)
        {
            Gerente gerente = BuscarNoBancoPorId(id);
            if (gerente != null)
            {
                ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
                return Ok(gerenteDTO);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperarGerentes()
        {
            return _context.Gerente;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Gerente gerente = BuscarNoBancoPorId(id);

            if (gerente == null)
            {
                return NotFound();
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDTO gerenteDTO)
        {
            Gerente gerente = BuscarGerentePorIdNoBanco(id);

            if (gerente == null)
            {
                return NotFound();
            }
            _mapper.Map(gerenteDTO, filme);
            _context.SaveChanges();
            return NoContent();
        }

        private Gerente BuscarNoBancoPorId(int id)
        {
            return _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
        }
    }
}
