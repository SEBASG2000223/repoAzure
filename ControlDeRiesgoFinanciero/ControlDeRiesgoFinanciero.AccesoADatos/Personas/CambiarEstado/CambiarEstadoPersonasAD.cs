using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.CambiarEstado;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.Personas.CambiarEstado
{
    public class CambiarEstadoPersonasAD : ICambiarEstadoPersonasAD
    {
        Contexto _elContexto;
        IFecha _fecha;

        public CambiarEstadoPersonasAD(IFecha fecha)
        {
            _elContexto = new Contexto();
            _fecha = fecha;
        }
        public async Task<bool> CambiarEstado(int idPersona, bool nuevoEstado)
        {
            var persona = await _elContexto.PersonasTabla
                .FirstOrDefaultAsync(laPersona => laPersona.IdPersona == idPersona);

            if (persona != null)
            {
                persona.Estado = nuevoEstado;
                persona.FechaDeModificacion = _fecha.ObtenerFecha();
                _elContexto.Entry(persona).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
