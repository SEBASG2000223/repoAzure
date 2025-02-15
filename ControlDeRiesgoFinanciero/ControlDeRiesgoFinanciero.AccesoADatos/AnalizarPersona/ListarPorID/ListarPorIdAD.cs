using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona.ListarPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.AnalizarPersona.ListarPorID
{
    public class ListarPorIdAD : IListarPorIdAD
    {

        Contexto _elContexto;

        public ListarPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public List<AnalizarPersonaDto> Listar(int IdPersona)
        {
            var laListaDeAnalisis = (from elAnalisis in _elContexto.AnalizarPersonaTabla
                                     where elAnalisis.IdPersona == IdPersona
                                     select new AnalizarPersonaDto
                                     {
                                         IdAnalisis = elAnalisis.IdAnalisis,
                                         IdPersona = elAnalisis.IdPersona,
                                         NivelDeRiesgoGenerado = elAnalisis.NivelDeRiesgoGenerado,
                                         TotalDePalabrasClaveEncontradas = elAnalisis.TotalDePalabrasClaveEncontradas,
                                         CanitdadDeArchivosEmparejados = elAnalisis.CanitdadDeArchivosEmparejados,
                                         FechaDeAnalisis = elAnalisis.FechaDeAnalisis.ToString(),
                                         Comentario = elAnalisis.Comentario
                                     }).ToList(); 

            return laListaDeAnalisis;
        }

    }
}
