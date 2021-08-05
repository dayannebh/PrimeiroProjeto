using PrimeiroProjeto.Models.Entity;

namespace PrimeiroProjeto.Models.CasoDeUso
{
    public interface IGetByDocumentCasoDeUso
    {
        Pessoa Execute(string documento);
    }
}
