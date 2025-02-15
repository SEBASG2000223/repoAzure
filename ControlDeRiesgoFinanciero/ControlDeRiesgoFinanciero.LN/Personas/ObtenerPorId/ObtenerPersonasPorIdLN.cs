using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.Personas.ObtenerPorId
{
    public class ObtenerPersonasPorIdLN : IObtenerPersonasPorIdLN
    {
        IObtenerPersonasPorIdAD _obtenerPorIdAD;

        public ObtenerPersonasPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPersonasPorIdAD();
        }

        public PersonasDto Obtener(int IdPersona)
        {
            PersonasTabla laPersonaEnBD = _obtenerPorIdAD.Obtener(IdPersona);
            PersonasDto laPersonaAMostrar = ConvertirAPersonaAMostrar(laPersonaEnBD);
            return laPersonaAMostrar;
        }

        private PersonasDto ConvertirAPersonaAMostrar(PersonasTabla laPersonaEnBD)
        {
            return new PersonasDto
            {
                IdPersona = laPersonaEnBD.IdPersona,
                IdentificacionPersona = laPersonaEnBD.IdentificacionPersona,
                TipoIdentificacion = laPersonaEnBD.TipoIdentificacion,
                NombrePersona = laPersonaEnBD.NombrePersona,
                PrimerApellidoPersona = laPersonaEnBD.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersonaEnBD.SegundoApellidoPersona,
                Telefono = laPersonaEnBD.Telefono,
                CorreoElectronico = laPersonaEnBD.CorreoElectronico,
                Direccion = laPersonaEnBD.Direccion,
                EstadoDeRiesgo = laPersonaEnBD.EstadoDeRiesgo,
                FechaDeRegistro = laPersonaEnBD.FechaDeRegistro.ToString(),
                FechaDeModificacion = laPersonaEnBD.FechaDeModificacion.ToString(),
                Estado = laPersonaEnBD.Estado
            };
        }
    }
}
