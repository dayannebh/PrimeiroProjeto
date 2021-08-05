using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Models;
using PrimeiroProjeto.Models.CasoDeUso;
using PrimeiroProjeto.Models.Entity;

namespace PrimeiroProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IGetByDocumentCasoDeUso _getByDocumentCasoDeUso;
        private readonly IGetByNomeCasoDeUso _getByNomeCasoDeUso;
        private readonly ICriarPessoaCasoDeUso _criarPessoaCasoDeUso;

        public PessoaController(IPessoaRepositorio pessoaRepositorio, IGetByDocumentCasoDeUso getByDocumentCasoDeUso, IGetByNomeCasoDeUso getByNomeCasoDeUso, ICriarPessoaCasoDeUso criarPessoaCasoDeUso)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _getByDocumentCasoDeUso = getByDocumentCasoDeUso;
            _getByNomeCasoDeUso = getByNomeCasoDeUso;
            _criarPessoaCasoDeUso = criarPessoaCasoDeUso;
        }

        [HttpGet]
        [Route("GetByDocument")]
        public IActionResult Get(string documento)
        {
            var pessoa = _getByDocumentCasoDeUso.Execute(documento);
            return Ok(pessoa);
        }
        
        [HttpGet]
        [Route("GetByNome")]
        public IActionResult GetByNome(string nome)
        {
            var pessoa = _getByNomeCasoDeUso.Execute(nome);
            return Ok(pessoa);
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult CriarPessoa(Pessoa pessoa)
        {
            var pessoaId = _criarPessoaCasoDeUso.Execute(pessoa);
            return Ok(pessoaId);
        }
    }
}
