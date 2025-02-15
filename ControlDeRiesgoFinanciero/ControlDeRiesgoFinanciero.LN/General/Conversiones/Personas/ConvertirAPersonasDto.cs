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
    public class ConvertirAPersonasDto : IConvertirAPersonasDto
    {
        public PersonasDto ConvertirObjetoAPersonasDto(PersonasTabla laPersona)
        {
            return new PersonasDto
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
                FechaDeRegistro = laPersona.FechaDeRegistro.ToString("dd - MM - yyyy hh: mm tt"),
                FechaDeModificacion = laPersona.FechaDeModificacion.ToString("dd - MM - yyyy hh: mm tt")
            };
        }
    }
}
