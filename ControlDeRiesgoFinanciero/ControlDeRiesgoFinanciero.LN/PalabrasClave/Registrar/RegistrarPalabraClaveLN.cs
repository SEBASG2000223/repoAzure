using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Registrar;
using ControlDeRiesgoFinanciero.LN.General;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.PalabrasClave.Registrar
{
    public class RegistrarPalabraClaveLN : IRegistrarPalabraClaveLN
    {
        IRegistrarPalabraClaveAD _registrarPalabraClaveAD;
        IFecha _fecha;
        IConvertirAPalabrasClaveTabla _convertirAPalabraClaveTabla;

        public RegistrarPalabraClaveLN()
        {
            _registrarPalabraClaveAD = new RegistrarPalabraClaveAD();
            _fecha = new Fecha();
            _convertirAPalabraClaveTabla = new ConvertirAPalabrasClaveTabla();
        }

        public async Task<int> Guardar(PalabrasClaveDto modelo)
        {
            modelo.Estado = true;
            int cantidadDeDatosGuardados = await _registrarPalabraClaveAD.Guardar(_convertirAPalabraClaveTabla.ConvertirObjetoAPalabrasClaveTabla(modelo));
            return cantidadDeDatosGuardados;
        }
    }
}
