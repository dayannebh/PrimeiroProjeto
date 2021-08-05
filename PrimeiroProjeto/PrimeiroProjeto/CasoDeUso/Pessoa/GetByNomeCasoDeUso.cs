using PrimeiroProjeto.Models;
using PrimeiroProjeto.Models.CasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroProjeto.CasoDeUso.Pessoa
{
    public class GetByNomeCasoDeUso : IGetByNomeCasoDeUso
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public GetByNomeCasoDeUso (IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public Models.Entity.Pessoa Execute (string nome)
        {
            var pessoa = _pessoaRepositorio.GetByNome(nome);
            return pessoa;
        }  
    }
}
