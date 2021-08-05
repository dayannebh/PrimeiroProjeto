using PrimeiroProjeto.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Models.CasoDeUso
{
    public interface IGetByNomeCasoDeUso
    {
        Pessoa Execute(string nome);
    }
}
