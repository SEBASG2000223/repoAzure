using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Eliminar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Eliminar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Eliminar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadPersona.Eliminar
{
    public class EliminarActividadPersonaLN : IEliminarActividadPersonaLN
    {
        IEliminarActividadPersonaAD _eliminarActividadesAD;
        IConvertirActividadPersonaDtoAActividadPersonaTabla _convertirObjeto;

        public EliminarActividadPersonaLN()
        {
            _eliminarActividadesAD = new EliminarActividadPersonaAD();
            _convertirObjeto = new ConvertirActividadPersonaDtoAActividadPersonaTabla();
        }

        public async Task<int> Desactivar(ActividadPersonaDto lasActividadesPersonaDesactivar)
        {
            int cantidadDeDatosActualizados = await _eliminarActividadesAD.Desactivar(_convertirObjeto.Convertir(lasActividadesPersonaDesactivar));
            return cantidadDeDatosActualizados;
        }

       
    }
}
