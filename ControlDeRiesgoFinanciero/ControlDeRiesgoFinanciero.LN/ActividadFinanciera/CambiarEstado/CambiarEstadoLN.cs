
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.CambiarEstado;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadFinanciera;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.CambiarEstado;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadFinanciera
{
    public class CambiarEstadoLN: ICambiarEstadoLN
    {
         ICambiarEstadoAD _cambiarEstadoAD;

        public CambiarEstadoLN(IFecha fecha)
        {
            _cambiarEstadoAD = new CambiarEstadoAD(fecha);
        }
        public async Task<bool> CambiarEstado(int idActividad, bool nuevoEstado)
        {
            return await _cambiarEstadoAD.CambiarEstado(idActividad, nuevoEstado);
        }
    }
}
