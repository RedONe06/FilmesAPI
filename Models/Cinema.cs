﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoFK { get; set; }
        public int GerenteFK { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        public int EnderecoId { get; set; }
    }
}