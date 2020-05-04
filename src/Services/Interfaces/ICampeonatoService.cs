using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface ICampeonatoService
    {
        IList<CampeonatoViewModel> RecuperarDadosCampeonato();
        CampeonatoViewModel RecuperarDadosCampeonato(int ano);
    }
}
