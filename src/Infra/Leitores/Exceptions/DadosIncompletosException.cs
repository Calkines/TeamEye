using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Infra.Leitores.Exceptions
{
    public class DadosIncompletosException : Exception
    {
        public DadosIncompletosException() : base() { }
        public DadosIncompletosException(string message) : base(message) { }
    }
}
