using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.CambiarEstado;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.CambiarEstado
{
    public class CambiarEstadoAD : ICambiarEstadoAD
    {
        Contexto _elContexto;
        IFecha _fecha;

        public CambiarEstadoAD(IFecha fecha)
        {
            _elContexto = new Contexto();
            _fecha = fecha;


        }

        public async Task<bool> CambiarEstado(int idActividad, bool nuevoEstado)
        {
            var actividad = await _elContexto.ActividadFinancieraTabla
                .FirstOrDefaultAsync(laActividad => laActividad.IdActividadFinanciera == idActividad);

            if (actividad != null)
            {
                actividad.Estado = nuevoEstado;
                actividad.FechaDeModificacion = _fecha.ObtenerFecha();
                _elContexto.Entry(actividad).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
