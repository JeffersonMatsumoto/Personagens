using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Personagens.WebApiI.Manha.Domains;
using Senai.Personagens.WebApiI.Manha.Interfaces;

namespace Senai.Personagens.WebApiI.Manha.Repositories
{
    public class PersonagensRepository : IPersonagensRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress; initial catalog=SENAI_PERSONAGENS_WEBAPI_MANHA; user id=sa; pwd = 132";

        public void Cadastrar(PersonagensDomain personagem)
        {
            string InsertQuery = "INSERT INTO PERSONAGENS (NOME, LANCAMENTO) VALUES (@NOME, @LANCAMENTO)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", personagem.Nome);
                    cmd.Parameters.AddWithValue("@LANCAMENTO", personagem.Lancamento);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PersonagensDomain> Listar()
        {
            string SelectQuery = "SELECT ID, NOME, LANCAMENTO FROM PERSONAGENS";
            List<PersonagensDomain> ListaPersonagens = new List<PersonagensDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(SelectQuery, con)) //para executar
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        PersonagensDomain personagem = new PersonagensDomain()
                        {
                            Id = Convert.ToInt32(sdr["ID"]),
                            Nome = sdr["NOME"].ToString(),
                            Lancamento = sdr["LANCAMENTO"].ToString()
                        };

                        ListaPersonagens.Add(personagem);
                    }
                }
                return ListaPersonagens;
            }
        }
    }
}
