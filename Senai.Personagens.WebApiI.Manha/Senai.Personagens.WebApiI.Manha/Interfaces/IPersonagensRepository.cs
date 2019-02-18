using Senai.Personagens.WebApiI.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Personagens.WebApiI.Manha.Interfaces
{
    interface IPersonagensRepository
    {
        List<PersonagensDomain> Listar();
        void Cadastrar(PersonagensDomain instituicao);
    }
}
