using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.Personas.Listar
{
    public class ListarPersonasAD : IListarPersonasAD
    {
        Contexto _elContexto;

        public ListarPersonasAD()
        {
            _elContexto = new Contexto();
        }

        public List<PersonasDto> Listar()
        {
            List<PersonasDto> laListaDePersonas = (from laPersona in _elContexto.PersonasTabla
                                                   select new PersonasDto
                                                   {
                                                       IdPersona = laPersona.IdPersona,
                                                       IdentificacionPersona = laPersona.IdentificacionPersona,
                                                       TipoIdentificacion = laPersona.TipoIdentificacion,
                                                       NombrePersona = laPersona.NombrePersona,
                                                       PrimerApellidoPersona = laPersona.PrimerApellidoPersona,
                                                       SegundoApellidoPersona = laPersona.SegundoApellidoPersona,
                                                       Telefono = laPersona.Telefono,
                                                       CorreoElectronico = laPersona.CorreoElectronico,
                                                       Direccion = laPersona.Direccion,
                                                       EstadoDeRiesgo = laPersona.EstadoDeRiesgo,
                                                       FechaDeModificacion = laPersona.FechaDeModificacion.ToString(),
                                                       FechaDeRegistro = laPersona.FechaDeRegistro.ToString(),
                                                       Estado = laPersona.Estado
                                                   }).ToList();
            return laListaDePersonas;
        }
    }
}
