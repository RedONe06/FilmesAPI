using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService service)
        {
            _cinemaService = service;
        }
        
        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDTO> readDTO = _cinemaService.RecuperarCinemas(nomeDoFilme);

            if(readDTO == null)
            {
                return NotFound();
            }
            return Ok(readDTO);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO readDTO = _cinemaService.AdicionarCinema(cinemaDTO);
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readDTO.Id }, readDTO);
        }

        public IActionResult RecuperaCinemaPorId(int id)
        {
            ReadCinemaDTO readDTO = _cinemaService.RecuperarCinemaPorId(id);
            
            if(readDTO == null)
            {
                return NotFound();
            }
            return Ok(readDTO);
        }

        

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            Result resultado = _cinemaService.AtualizarCinema(id, cinemaDTO);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result resultado = _cinemaService.DeletarCinema(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
