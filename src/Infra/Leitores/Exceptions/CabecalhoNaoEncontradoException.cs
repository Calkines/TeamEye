using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Infra.Leitores.Exceptions
{
    public class CabecalhoNaoEncontradoException : Exception
    {
        public CabecalhoNaoEncontradoException() : base() { }
        public CabecalhoNaoEncontradoException(string message) : base(message) { }
    }
}
