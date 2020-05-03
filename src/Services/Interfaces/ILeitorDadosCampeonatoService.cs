using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface ILeitorDadosCampeonatoService
    {
        DadosCampeonatoViewModel ImportarDados(Stream stream);
    }
}
