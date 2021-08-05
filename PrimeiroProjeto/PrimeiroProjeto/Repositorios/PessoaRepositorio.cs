using Dapper;
using Microsoft.Data.SqlClient;
using PrimeiroProjeto.Models;
using PrimeiroProjeto.Models.Entity;
using System;
using System.Data;

namespace PrimeiroProjeto.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
 
        public Pessoa GetByDocument(string documento)
        {
            Pessoa resultado = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Dayanne",
                Documento = "12345678911"
            };

            return resultado;
        }

        public Pessoa GetByNome(string nome)
        {
            Pessoa resultado = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Dayanne",
                Documento = "12345678911"
            };

            return resultado;
        }

        public Guid CriarPessoa(Pessoa pessoa)
        {
            const string sql = @"insert
                into pessoas (id, nome, documento) 
                output inserted.id 
                values 
                    (@id, 
                    @nome, 
                    @documento)";

            var param = new DynamicParameters();

            param.Add("@id", pessoa.Id, DbType.Guid);
            param.Add("@nome", pessoa.Nome, DbType.String);
            param.Add("@documento", pessoa.Documento, DbType.String);

            using var connection = new SqlConnection("Server=(localdb)\\servidor;Database=primeiroProjeto");

            var value = connection.QueryFirst<Guid>(sql, param);

            return value;
        }
    }
}
