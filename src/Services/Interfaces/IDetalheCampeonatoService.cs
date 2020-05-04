using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface IDetalheCampeonatoService
    {
        List<DetalheCampeonatoViewModel> SelecionarDetalheCampeonatoPorTime(int timeId);
        List<DetalheCampeonatoViewModel> SelecionarDetalheCampeonatoPorTime(List<int> timesId);
    }
}
