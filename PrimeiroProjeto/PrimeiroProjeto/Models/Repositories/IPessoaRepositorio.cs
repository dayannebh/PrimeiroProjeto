using PrimeiroProjeto.Models.Entity;
using System;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Models
{
    public interface IPessoaRepositorio
    {
        Pessoa GetByDocument(string documento);
        Pessoa GetByNome(string nome);
        Guid CriarPessoa(Pessoa pessoa);
    };
}
