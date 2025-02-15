using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Listar
{
    public class ListarActividadFinancieraAD: IListarActividadFinancieraAD
    {
        Contexto _elContexto;

        public ListarActividadFinancieraAD()
        {
            _elContexto = new Contexto();
        }

        public List<ActividadFinancieraDto> Listar()
        {
            List<ActividadFinancieraDto> laListaDeActividades = (from laActividad in _elContexto.ActividadFinancieraTabla
                                                   select new ActividadFinancieraDto
                                                   {
                                                       FechaDeRegistro = laActividad.FechaDeRegistro.ToString(),
                                                       FechaDeModificacion = laActividad.FechaDeModificacion.ToString(),
                                                       Estado = laActividad.Estado,                  
                                                       NivelDeRiesgo = laActividad.NivelDeRiesgo,
                                                       DescripcionActividadFinanciera = laActividad.DescripcionActividadFinanciera,
                                                       NombreActividadFinanciera = laActividad.NombreActividadFinanciera,
                                                       IdActividadFinanciera = laActividad.IdActividadFinanciera
                                                   }).ToList();
            return laListaDeActividades;
        }
    }
}
