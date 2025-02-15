using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona.ListarPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.ListarPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.AnalizarPersona.ListarPorID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.AnalizarPersona.ListarPorId
{
    public class ListarPorIdLN: IListarPorIdLN
    {

        IListarPorIdAD _listarPorIdAD;
        public ListarPorIdLN()
        {
            _listarPorIdAD = new ListarPorIdAD();

        }

        public List<AnalizarPersonaDto> ListarPorId(int idPersona)
        {
            
            List<AnalizarPersonaDto> laListaDeAnalisis = _listarPorIdAD.Listar(idPersona);
            return laListaDeAnalisis;
        }


        private List<AnalizarPersonaDto> ObtenerLaListaConvertida(List<AnalizarPersonaTabla> laListaDeAnalisis)
        {
            List<AnalizarPersonaDto> laListaDeAnalisises = new List<AnalizarPersonaDto>();
            foreach (AnalizarPersonaTabla elAnalisis in laListaDeAnalisis)
            {
                laListaDeAnalisises.Add(ConvertirObjetoAnalisisDto(elAnalisis));
            }
            return laListaDeAnalisises;
        }
        private AnalizarPersonaDto ConvertirObjetoAnalisisDto(AnalizarPersonaTabla elAnalisis)
        {
            return new AnalizarPersonaDto
            {
                FechaDeAnalisis = elAnalisis.FechaDeAnalisis.ToString("dd-MM-yyyy hh:mm tt"),
                Comentario = elAnalisis.Comentario,
                IdAnalisis = elAnalisis.IdAnalisis,
                IdPersona = elAnalisis.IdPersona,
                NivelDeRiesgoGenerado = elAnalisis.NivelDeRiesgoGenerado,
                TotalDePalabrasClaveEncontradas = elAnalisis.TotalDePalabrasClaveEncontradas,
                CanitdadDeArchivosEmparejados = elAnalisis.CanitdadDeArchivosEmparejados,
            };
        }
    }
}
