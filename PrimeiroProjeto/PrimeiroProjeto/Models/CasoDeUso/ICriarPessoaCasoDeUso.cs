using PrimeiroProjeto.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Models.CasoDeUso
{
    public interface ICriarPessoaCasoDeUso
    {
        Guid Execute(Pessoa pessoa);
    }
}
