using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Actualizar
{
    public class ActualizarActividadPersonaAD : IActualizarActividadPersonaAD
    {
        Contexto _elContexto;

        public ActualizarActividadPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Actualizar(ActividadPersonaTabla ActividadPersonaActualizar)
        {
           
            ActividadPersonaTabla laActividadPersonaEnBD = _elContexto.ActividadPersonaTabla.Where(laActividadPersona => laActividadPersona.IdActividadPersona == ActividadPersonaActualizar.IdActividadPersona).FirstOrDefault();

            laActividadPersonaEnBD.IdActividadPersona = ActividadPersonaActualizar.IdActividadPersona;
            laActividadPersonaEnBD.Estado = ActividadPersonaActualizar.Estado;
          
          
            EntityState estado = _elContexto.Entry(laActividadPersonaEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }


    }
}
