﻿using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ListarPersonas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.ListarPersonas;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.ListarPersonasPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadPersona.ListarPersonaPorId
{
    public class ListarPersonaPorIdLN : IListarPersonasPorIdLN
    {

        IListarPersonasPorIdAD _listarActividadesAD;
        public ListarPersonaPorIdLN()
        {
            _listarActividadesAD = new ListarPersonasPorIDAD();

        }
        public List<ActividadPersonaDto> ListarActividades(int idPersona)
        {
            List<ActividadPersonaDto> laListaDeActividades = _listarActividadesAD.ListarActividades(idPersona);
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
