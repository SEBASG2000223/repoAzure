using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Editar
{
    public class EditarActividadFinancieraLN: IEditarActividadFinancieraLN
    {
        IEditarActividadFinancieraAD _editarActividadAD;
        IConvertirActividadDtoAlActividadTabla _convertirObjeto;
        public EditarActividadFinancieraLN()
        {
            _editarActividadAD = new EditarActividadFinancieraAD();
            _convertirObjeto = new ConvertirActividadFinancieraDtoAlActividadFinancieraTabla();
        }


        public async Task<int> Actualizar(ActividadFinancieraDto laActividadEnVista)
        {
            int cantidadDeDatosActualizados = await _editarActividadAD.Actualizar(_convertirObjeto.Convertir(laActividadEnVista));
            return cantidadDeDatosActualizados;
        }
    }
}
