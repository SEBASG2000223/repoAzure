using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.Personas
{
    public class ConvertirAPersonasTabla : IConvertirAPersonasTabla
    {
        IFecha _fecha;

        public ConvertirAPersonasTabla()
        {
            _fecha = new Fecha();
        }

        public PersonasTabla ConvertirObjetoAPersonasTabla(PersonasDto laPersona)
        {
            return new PersonasTabla
            {
                IdentificacionPersona = laPersona.IdentificacionPersona,
                TipoIdentificacion = laPersona.TipoIdentificacion,
                NombrePersona = laPersona.NombrePersona,
                PrimerApellidoPersona = laPersona.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersona.SegundoApellidoPersona,
                EstadoDeRiesgo = laPersona.EstadoDeRiesgo,
                Estado = laPersona.Estado,
                IdPersona = laPersona.IdPersona,
                CorreoElectronico = laPersona.CorreoElectronico,
                Telefono = laPersona.Telefono,
                Direccion = laPersona.Direccion,
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha()
            };
        }
    }
}
