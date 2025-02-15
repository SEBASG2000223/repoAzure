using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.AnalizarPersona.Listar
{
    public class ListarAnalisisPersonaAD : IListarAnalisisPersonaAD
    {
        Contexto _elContexto;
        public ListarAnalisisPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public List<ListarAnalisisPersonaDto> Listar()
        {
            List<ListarAnalisisPersonaDto> laListaDeAnalisis = (from persona in _elContexto.PersonasTabla
                                                          join analisis in _elContexto.AnalizarPersonaTabla
                                                          on persona.IdPersona equals analisis.IdPersona
                                                          into analisisGrupo
                                                          where analisisGrupo.Any()
                                                          select new ListarAnalisisPersonaDto
                                                          {
                                                              IdPersona = persona.IdPersona,
                                                            TipoIdentificacion = persona.TipoIdentificacion,
                                                            NombrePersona = persona.NombrePersona,
                                                            PrimerApellidoPersona = persona.PrimerApellidoPersona,
                                                            SegundoApellidoPersona = persona.SegundoApellidoPersona,
                                                            NivelDeRiesgo = persona.EstadoDeRiesgo,
                                                            FechaUltimoAnalisis = analisisGrupo.Max(a => a.FechaDeAnalisis)
                                                          }).ToList();
            return laListaDeAnalisis;
        }
    }
}
