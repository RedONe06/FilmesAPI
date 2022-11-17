﻿using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO_s
{
    public class ReadCinemaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}
