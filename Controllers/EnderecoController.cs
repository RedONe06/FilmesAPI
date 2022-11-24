using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        EnderecoService _enderecoService;

        public EnderecoController(EnderecoService service)
        {
            _enderecoService = service;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO readDTO = _enderecoService.AdicionarEndereco(enderecoDTO);
            return CreatedAtAction(nameof(ResgatarEnderecoPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> ResgatarEnderecos()
        {
            IEnumerable<ReadEnderecoDTO> readDTO = _enderecoService.ResgatarEnderecos();
            return readDTO;
        }

        [HttpGet("{id}")]
        public IActionResult ResgatarEnderecoPorId(int id)
        {
            ReadEnderecoDTO readDTO = _enderecoService.ResgatarEnderecoPorId(id);

            if (readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            Result resultado = _enderecoService.AtualizarEndereco(id, enderecoDTO);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Result resultado = _enderecoService.DeletarEndereco(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
