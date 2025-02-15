using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadFinanciera
{
    public class ConvertirActividadFinancieraDtoAlActividadFinancieraTabla : IConvertirActividadDtoAlActividadTabla
    {
        Fecha _fecha;

        public ConvertirActividadFinancieraDtoAlActividadFinancieraTabla()
        {
            _fecha = new Fecha();
        }
        public ActividadFinancieraTabla Convertir(ActividadFinancieraDto laActividad)
        {
            return new ActividadFinancieraTabla
            {
                FechaDeModificacion = _fecha.ObtenerFecha(),
                NombreActividadFinanciera = laActividad.NombreActividadFinanciera,
                DescripcionActividadFinanciera = laActividad.DescripcionActividadFinanciera,
                Estado = laActividad.Estado,
                IdActividadFinanciera = laActividad.IdActividadFinanciera
            };
        }
    }
}
