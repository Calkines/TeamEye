using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEye.Crosscutting.Utils
{
    public static class LogHelpers
    {
        public static string FormatarMensagemErro(Exception ex)
        {
            return $"Falha na leitura de arquivo. \n Message: {ex.Message}.\nStackTrace: {ex.StackTrace}";
        }
    }
}
