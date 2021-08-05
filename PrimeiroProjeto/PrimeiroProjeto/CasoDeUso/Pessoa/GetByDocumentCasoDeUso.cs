using PrimeiroProjeto.Models;
using PrimeiroProjeto.Models.CasoDeUso;

namespace PrimeiroProjeto.CasoDeUso
{
    public class GetByDocumentCasoDeUso : IGetByDocumentCasoDeUso
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public GetByDocumentCasoDeUso(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public Models.Entity.Pessoa Execute(string documento)
        {
            var pessoa = _pessoaRepositorio.GetByDocument(documento);
            return pessoa;
        }
    }
}
