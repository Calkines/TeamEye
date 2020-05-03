using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Services.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface ILeitorDadosCampeonatoService
    {
        DadosCampeonatoViewModel BuscarDados();
    }
}
