using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Data.DTO_s.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService service)
        {
            _gerenteService = service;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO gerenteDTO)
        {
            ReadGerenteDTO readDTO = _gerenteService.AdicionarGerente(gerenteDTO);
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet("{id}")]
        public object RecuperarGerentePorId(int id)
        {
            ReadGerenteDTO readDTO = _gerenteService.RecuperarGerentePorId(id);
            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<ReadGerenteDTO> RecuperarGerentes()
        {
            IEnumerable<ReadGerenteDTO> readDTO = _gerenteService.RecuperarGerentes();
            return readDTO;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result resultado = _gerenteService.DeletarGerente(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDTO gerenteDTO)
        {
            Result resultado = _gerenteService.AtualizarGerente(id, gerenteDTO);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
