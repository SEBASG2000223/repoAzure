using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadPersona
{
    public interface IConvertirActividadPersonaDtoAActividadPersonaTabla
    {
        ActividadPersonaTabla Convertir(ActividadPersonaDto lasActividades);
    }
}
