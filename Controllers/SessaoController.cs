using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s.Gerente;
using FilmesAPI.Data.DTO_s.Sessao;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        private object RecuperaSessaoPorId(int id)
        {
            Sessao sessao = BuscarNoBancoPorId(id);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);
                return Ok(sessaoDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Sessao sessao = BuscarNoBancoPorId(id);

            if (sessao == null)
            {
                return NotFound();
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDTO sessaoDTO)
        {
            Sessao sessao = BuscarNoBancoPorId(id);

            if (sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDTO, sessao);
            _context.SaveChanges();
            return NoContent();
        }
        private Sessao BuscarNoBancoPorId(int id)
        {
            return _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        }
    }
}
