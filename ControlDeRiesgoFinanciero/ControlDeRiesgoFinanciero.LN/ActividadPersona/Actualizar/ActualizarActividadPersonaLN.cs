using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadPersona.Actualizar
{
    public class ActualizarActividadPersonaLN : IActualizarActividadPersonaLN
    {

        IActualizarActividadPersonaAD _actualizarActividadPersona;
        IConvertirActividadPersonaDtoAActividadPersonaTabla _convertirObjeto;

        public ActualizarActividadPersonaLN()
        {
            _actualizarActividadPersona = new ActualizarActividadPersonaAD();
            _convertirObjeto = new ConvertirActividadPersonaDtoAActividadPersonaTabla();
        }
        public async Task<int> Actualizar(ActividadPersonaDto actividadPersonaActualizar)
        {
            int cantidadDeDatosActualizados = await _actualizarActividadPersona.Actualizar(_convertirObjeto.Convertir(actividadPersonaActualizar));
            return cantidadDeDatosActualizados;
        }
    }
}
