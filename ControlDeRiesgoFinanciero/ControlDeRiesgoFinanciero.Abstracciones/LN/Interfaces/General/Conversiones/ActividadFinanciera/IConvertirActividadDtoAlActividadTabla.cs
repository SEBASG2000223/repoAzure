using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadFinanciera
{
    public interface IConvertirActividadDtoAlActividadTabla
    {
        ActividadFinancieraTabla Convertir(ActividadFinancieraDto laActividad);
    }
}
