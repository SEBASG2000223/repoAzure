using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.Editar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.Personas.Editar
{
    public class EditarPersonasLN : IEditarPersonasLN
    {
        IEditarPersonasAD _editarPersonasAD;
        IConvertirAPersonasTabla _convertirAPersonasTabla;
        
        public EditarPersonasLN()
        {
            _editarPersonasAD = new EditarPersonasAD();
            _convertirAPersonasTabla = new ConvertirAPersonasTabla();
        }

        public async Task<int> Editar(PersonasDto laPersonaEnVista)
        {
            int cantidadDeDatosGuardados = await _editarPersonasAD.Editar(_convertirAPersonasTabla.ConvertirObjetoAPersonasTabla(laPersonaEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}
