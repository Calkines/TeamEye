using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface ICampeonatoService
    {
        IList<CampeonatoResumidoViewModel> RecuperarDadosCampeonato();
        CampeonatoViewModel RecuperarDadosCampeonato(int ano);
    }
}
