﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO_s.Gerente
{
    public class UpdateGerenteDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}