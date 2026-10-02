using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class FormatoCUITNoValidoException : ApplicationException
    {
        public FormatoCUITNoValidoException() : base()
        {
        }

        public FormatoCUITNoValidoException(string message) : base(message)
        {
        }

        public FormatoCUITNoValidoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
