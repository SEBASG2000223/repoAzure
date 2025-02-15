using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Listar
{
    public class ListarActividadFinancieraLN: IListarActividadFinancieraLN
    {
        IListarActividadFinancieraAD _listarActividadFinancieraAD;
        public ListarActividadFinancieraLN()
        {
            _listarActividadFinancieraAD = new ListarActividadFinancieraAD();

        }

        public List<ActividadFinancieraDto> Listar()
        {
            List<ActividadFinancieraDto> laListaDeActividades = _listarActividadFinancieraAD.Listar();
            return laListaDeActividades;
        }

        private List<ActividadFinancieraDto> ObtenerLaListaConvertida(List<ActividadFinancieraTabla> laListaDeActividad)
        {
            List<ActividadFinancieraDto> laListaDeActividades = new List<ActividadFinancieraDto>();
            foreach (ActividadFinancieraTabla laActividad in laListaDeActividad)
            {
                laListaDeActividades.Add(ConvertirObjetoInventarioDto(laActividad));
            }
            return laListaDeActividades;
        }
        private ActividadFinancieraDto ConvertirObjetoInventarioDto(ActividadFinancieraTabla laActividad)
        {
            return new ActividadFinancieraDto
            {
                FechaDeRegistro = laActividad.FechaDeRegistro.ToString("dd-MM-yyyy hh:mm tt"),
                FechaDeModificacion = laActividad.FechaDeModificacion.ToString("dd-MM-yyyy hh:mm tt"),
                Estado = laActividad.Estado,
                NivelDeRiesgo = laActividad.NivelDeRiesgo,
                DescripcionActividadFinanciera = laActividad.DescripcionActividadFinanciera,
                NombreActividadFinanciera = laActividad.NombreActividadFinanciera,
                IdActividadFinanciera = laActividad.IdActividadFinanciera
            };
        }
    }
}
