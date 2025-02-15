using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.CambiarEstado
{
    public interface ICambiarEstadoAD
    {
        Task<bool> CambiarEstado(int idActividad, bool nuevoEstado);
    }
}
