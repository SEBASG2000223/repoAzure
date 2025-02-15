using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.Registrar;
using ControlDeRiesgoFinanciero.LN.General;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.Personas.Registrar
{
    public class RegistrarPersonasLN : IRegistrarPersonasLN
    {
        IRegistrarPersonasAD _registrarPersonasAD;
        IFecha _fecha;
        IConvertirAPersonasTabla _convertirAPersonasTabla;

        public RegistrarPersonasLN()
        {
            _registrarPersonasAD = new RegistrarPersonasAD();
            _fecha = new Fecha();
            _convertirAPersonasTabla = new ConvertirAPersonasTabla();
        }

        public async Task<int> Guardar(PersonasDto modelo)
        {
            modelo.Estado = true;
            int cantidadDeDatosGuardados = await _registrarPersonasAD.Guardar(_convertirAPersonasTabla.ConvertirObjetoAPersonasTabla(modelo));
            return cantidadDeDatosGuardados;
        }
    }
}
