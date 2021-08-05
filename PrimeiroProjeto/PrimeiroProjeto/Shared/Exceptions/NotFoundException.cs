using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ReasonPhrase { get; private set; }
        public NotFoundException(string reasonPhrase, string requestUri) :
            base($"Request not found. Reason ReasonPhrase {reasonPhrase}, request Uri {requestUri}.")
        {
            ReasonPhrase = reasonPhrase;
        }
    }
}
