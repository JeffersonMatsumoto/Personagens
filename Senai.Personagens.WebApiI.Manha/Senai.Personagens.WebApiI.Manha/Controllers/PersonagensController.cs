using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Personagens.WebApiI.Manha.Domains;
using Senai.Personagens.WebApiI.Manha.Interfaces;
using Senai.Personagens.WebApiI.Manha.Repositories;

namespace Senai.Personagens.WebApiI.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class PersonagensController : ControllerBase
    {
        private IPersonagensRepository PersonagensRepository { get; set; }

        public PersonagensController()
        {
            PersonagensRepository = new PersonagensRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PersonagensRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(PersonagensDomain personagem)
        {
            try
            {
                PersonagensRepository.Cadastrar(personagem);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}