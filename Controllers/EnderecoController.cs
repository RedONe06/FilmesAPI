using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ResgatarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> ResgatarEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult ResgatarEnderecoPorId(int id)
        {
            Endereco endereco = BuscarNoBancoPorId(id);

            if (endereco != null)
            {
                ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

                return Ok(enderecoDTO);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = BuscarNoBancoPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = BuscarNoBancoPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

        private Endereco BuscarNoBancoPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        }
    }
}
