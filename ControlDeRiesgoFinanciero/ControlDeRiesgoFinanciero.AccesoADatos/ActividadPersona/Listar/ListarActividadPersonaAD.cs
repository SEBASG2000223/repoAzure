using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Listar
{
    public class ListarActividadPersonaAD : IListarActividadPersonaAD
    {

         Contexto _elContexto;

        public ListarActividadPersonaAD()
        {
            _elContexto = new Contexto();
        }


        public List<ActividadPersonaDto> Listar()
        {
            var actividadesDesactivadas = (from actividadPersona in _elContexto.ActividadPersonaTabla
                                           join actividadFinanciera in _elContexto.ActividadFinancieraTabla
                                           on actividadPersona.IdActividadFinanciera equals actividadFinanciera.IdActividadFinanciera
                                           where actividadPersona.Estado == false 
                                           select new ActividadPersonaDto
                                           {
                                               IdActividadPersona = actividadPersona.IdActividadPersona,
                                               IdActividadFinanciera = actividadPersona.IdActividadFinanciera,
                                               IdPersona = actividadPersona.IdPersona,
                                               FechaDeRegistro = actividadPersona.FechaDeRegistro.ToString(),
                                               FechaDeModificacion = actividadPersona.FechaDeModificacion.ToString(),
                                               Estado = actividadPersona.Estado,
                                               NombreActividadFinanciera = actividadFinanciera.NombreActividadFinanciera,
                                               NivelDeRiesgo = actividadFinanciera.NivelDeRiesgo
                                           }).ToList();

            return actividadesDesactivadas;
        }
    }
}
