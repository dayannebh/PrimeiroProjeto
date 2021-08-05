using PrimeiroProjeto.Models;
using PrimeiroProjeto.Models.CasoDeUso;
using PrimeiroProjeto.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroProjeto.UseCase
{
    public class CriarPessoaCasoDeUso : ICriarPessoaCasoDeUso
    {
        public readonly IPessoaRepositorio _pessoaReposiorio;

        public CriarPessoaCasoDeUso(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaReposiorio = pessoaRepositorio;
        }

        public Guid Execute (Pessoa pessoa)
        {
            var response = _pessoaReposiorio.CriarPessoa(pessoa);
            return response;
        }
    }
}
