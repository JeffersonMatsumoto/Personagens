using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Personagens.WebApiI.Manha.Domains
{
    public class PersonagensDomain
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "O campo tem que ter no mínimo 3 caracteres e no máximo 150.")]
        [Required(ErrorMessage = "Informe o nome do personagem.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o lançamento.")]
        public string Lancamento { get; set; }
    }
}
