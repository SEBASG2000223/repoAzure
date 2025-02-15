using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadPersona.Listar
{
    public class ListarActividadPersonaLN : IListarActividadPersonaLN
    {
        IListarActividadPersonaAD _listarActividadesAD;
        public ListarActividadPersonaLN()
        {
            _listarActividadesAD = new ListarActividadPersonaAD();

        }
        public List<ActividadPersonaDto> Listar()
        {
            List<ActividadPersonaDto> laListaDeActividades = _listarActividadesAD.Listar();
            return laListaDeActividades;
        }

        private List<ActividadPersonaDto> ObtenerLaListaConvertida(List<ActividadPersonaTabla> laLista)
        {
            List<ActividadPersonaDto> laListaDeActividades = new List<ActividadPersonaDto>();
            foreach (ActividadPersonaTabla lasActividades in laLista)
            {
                laListaDeActividades.Add(ConvertirObjetoActividadesPersonaDto(lasActividades));
            }
            return laListaDeActividades;
        }
        private ActividadPersonaDto ConvertirObjetoActividadesPersonaDto(ActividadPersonaTabla lasActividades)
        {
            return new ActividadPersonaDto
            {
                FechaDeRegistro = lasActividades.FechaDeRegistro.ToString("dd-MM-yyyy hh:mm tt"),
                FechaDeModificacion = lasActividades.FechaDeModificacion.ToString("dd-MM-yyyy hh:mm tt"),
                IdActividadPersona = lasActividades.IdActividadPersona,
                IdActividadFinanciera = lasActividades.IdActividadFinanciera,
                IdPersona = lasActividades.IdPersona,
                Estado = lasActividades.Estado
            };
        }
    }
}
