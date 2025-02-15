using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Editar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.PalabrasClave.Editar
{
    public class EditarPalabraClaveLN : IEditarPalabraClaveLN
    {
        IEditarPalabraClaveAD _editarPalabraClave;
        IConvertirAPalabrasClaveTabla _convertirObjeto;

        public EditarPalabraClaveLN()
        {
            _editarPalabraClave = new EditarPalabraClaveAD();
            _convertirObjeto = new ConvertirAPalabrasClaveTabla();
        }

        public async Task<int> Editar(PalabrasClaveDto laPalabraEnVista)
        {
            int cantidadDeDatosActualizados = await _editarPalabraClave.Editar(_convertirObjeto.ConvertirObjetoAPalabrasClaveTabla(laPalabraEnVista));
            return cantidadDeDatosActualizados;
        }
    }
}
