using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadPersona
{
    public class ConvertirActividadPersonaDtoAActividadPersonaTabla: IConvertirActividadPersonaDtoAActividadPersonaTabla
    {
        IFecha _fecha;

        public ConvertirActividadPersonaDtoAActividadPersonaTabla()
        {
            _fecha = new Fecha();
        }

        public ActividadPersonaTabla Convertir(ActividadPersonaDto lasActividades)
        {
            return new ActividadPersonaTabla
            {


             FechaDeRegistro = _fecha.ObtenerFecha(),
             
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdActividadPersona = lasActividades.IdActividadPersona,
                IdActividadFinanciera = lasActividades.IdActividadFinanciera,
                IdPersona = lasActividades.IdPersona,
                Estado = lasActividades.Estado


            };


        }

    }
}
