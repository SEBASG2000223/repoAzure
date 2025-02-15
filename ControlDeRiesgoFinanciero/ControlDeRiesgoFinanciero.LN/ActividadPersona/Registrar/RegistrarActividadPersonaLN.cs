using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadPersona.Registrar
{
    public class RegistrarActividadPersonaLN : IRegistrarActividadPersonaLN
    {
        IRegistrarActividadPersonaAD _registrarActividadPersonaAD;
        IFecha _fecha;
        IObtenerPersonasPorIdAD _obtenerPersonasPorIdAD;

        public RegistrarActividadPersonaLN()
        {
            _fecha = new Fecha();
            _registrarActividadPersonaAD = new RegistrarActividadPersonaAD();
            _obtenerPersonasPorIdAD = new ObtenerPersonasPorIdAD();
        }
        public async Task<int> Registrar(ActividadPersonaDto modelo)
        {
            int idPersona = ObtenerIdPersona(modelo.IdPersona);
            int cantidadDeDatosAlmacenados = await _registrarActividadPersonaAD.Registrar(ConvertirObjetoActividadesPersonaTabla(modelo, idPersona));
           
            return cantidadDeDatosAlmacenados;
        }
        private int ObtenerIdPersona(int idPersona)
        {
            var persona = _obtenerPersonasPorIdAD.Obtener(idPersona);
            return persona.IdPersona;
        }
        private ActividadPersonaTabla ConvertirObjetoActividadesPersonaTabla(ActividadPersonaDto lasActividades, int idPersona)
        {
            return new ActividadPersonaTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdActividadPersona = lasActividades.IdActividadPersona,
                IdActividadFinanciera = lasActividades.IdActividadFinanciera,
                IdPersona = idPersona,
                Estado = lasActividades.Estado,

            };
        }
     
    }
}
