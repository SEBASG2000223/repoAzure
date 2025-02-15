using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadFinanciera
{
    public interface ICambiarEstadoLN
    {
        Task<bool> CambiarEstado(int idActividad, bool nuevoEstado);
    }
}
