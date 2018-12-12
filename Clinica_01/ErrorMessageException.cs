using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_01
{
    public class ErrorMessageException : Exception
    {
        public ErrorMessageException(string mensagem) 
            : base(mensagem)
        {
            
        }
    }
}
