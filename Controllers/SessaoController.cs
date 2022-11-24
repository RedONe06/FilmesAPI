using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Data.DTO_s.Gerente;
using FilmesAPI.Data.DTO_s.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        SessaoService _sessaoService;

        public SessaoController(SessaoService service)
        {
            _sessaoService = service;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            ReadSessaoDTO readDTO = _sessaoService.AdicionarSessao(sessaoDTO);
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet("{id}")]
        public object RecuperarSessaoPorId(int id)
        {
            ReadSessaoDTO readDTO = _sessaoService.RecuperarSessaoPorId(id);

            if(readDTO == null)
            {
                NotFound();
            }
            return Ok(readDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Result resultado = _sessaoService.DeletarSessao(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();

            
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDTO sessaoDTO)
        {
            Result resultado = _sessaoService.AtualizarSessao(id, sessaoDTO);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
