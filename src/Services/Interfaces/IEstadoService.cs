using System;
using System.Collections.Generic;
using System.Text;
using TeamEye.Crosscutting.ViewModel;

namespace TeamEye.Services.Interfaces
{
    public interface IEstadoService
    {
        IList<EstadoViewModel> RecuperarDadosTime();
        RetornoPorEstadoViewModel RecuperarDadosTime(int idEstado);
    }
}
