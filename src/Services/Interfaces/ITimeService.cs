using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface ITimeService
    {
        IList<TimeViewModel> RecuperarDadosTime();
        RetornoPorTimeViewModel RecuperarDadosTime(int id);
        IList<TimeViewModel> RecuperarDadosTimePorEstadoId(int estadoId);
    }
}
