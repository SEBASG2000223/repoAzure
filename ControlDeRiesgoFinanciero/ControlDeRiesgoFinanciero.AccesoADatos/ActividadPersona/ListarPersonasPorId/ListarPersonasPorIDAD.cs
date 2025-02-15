﻿using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ListarPersonas;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.ListarPersonasPorId
{
    public class ListarPersonasPorIDAD : IListarPersonasPorIdAD
    {

        Contexto _elContexto;

        public ListarPersonasPorIDAD()
        {
            _elContexto = new Contexto();
        }

        public List<ActividadPersonaDto> ListarActividades(int idPersona)
        {
            // Consulta LINQ para obtener las actividades asociadas al idPersona específico
            var laListaDeActividades = (from actividadPersona in _elContexto.ActividadPersonaTabla
                                        join actividadFinanciera in _elContexto.ActividadFinancieraTabla
                                        on actividadPersona.IdActividadFinanciera equals actividadFinanciera.IdActividadFinanciera
                                        where actividadPersona.Estado == true && actividadPersona.IdPersona == idPersona // Filtra por idPersona
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

            return laListaDeActividades;
        }
       
    }
}
