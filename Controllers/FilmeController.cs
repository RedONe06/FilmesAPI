using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FilmeController : ControllerBase
    {

        private FilmeService _filmeService;

        public FilmeController(FilmeService service)
        {
            _filmeService = service;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            ReadFilmeDTO readDTO=  _filmeService.AdicionarFilme(filmeDTO);
            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDTO> readDTO = _filmeService.RecuperarFilmes(classificacaoEtaria);

            if(readDTO != null)
            {
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            ReadFilmeDTO readDTO = _filmeService.RecuperarFilmePorId(id);
            if(readDTO != null)
            {
                return Ok(readDTO);
            } 
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Result resultado = _filmeService.AtualizarFilme(id, filmeDTO);
            
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result resultado = _filmeService.DeletarFilme(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            } 
            return NoContent();
        }
    }
}
