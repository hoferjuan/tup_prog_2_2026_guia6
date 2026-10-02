using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class FormatoNombreNoValidoException : ApplicationException
    {
        public FormatoNombreNoValidoException() : base()
        {
        }

        public FormatoNombreNoValidoException(string message) : base(message)
        {
        }

        public FormatoNombreNoValidoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
