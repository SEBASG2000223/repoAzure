using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadFinanciera.ObtenerPorId
{
    public class ObtenerActividadFinancieraPorIdLN : IObtenerActividadFinancieraPorIdLN
    {
        IObtenerActividadFinancieraPorID _obtenerPorIdActividadAD;
        public ObtenerActividadFinancieraPorIdLN()
        {
            _obtenerPorIdActividadAD = new ObtenerActividadFinancieraPorID();
        }

        public ActividadFinancieraDto Obtener(int id)
        {
            ActividadFinancieraTabla actividadEnBaseDeDatos = _obtenerPorIdActividadAD.Obtener(id);
            ActividadFinancieraDto laActividadAMostrar = ConvertirAInventarioAMostrar(actividadEnBaseDeDatos);
            return laActividadAMostrar;
        }

        private ActividadFinancieraDto ConvertirAInventarioAMostrar(ActividadFinancieraTabla actividadEnBaseDeDatos)
        {
            return new ActividadFinancieraDto
            {
                FechaDeModificacion = actividadEnBaseDeDatos.FechaDeModificacion.ToString(),
                Estado = actividadEnBaseDeDatos.Estado,
                NombreActividadFinanciera = actividadEnBaseDeDatos.NombreActividadFinanciera,
                DescripcionActividadFinanciera = actividadEnBaseDeDatos.DescripcionActividadFinanciera,
                IdActividadFinanciera = actividadEnBaseDeDatos.IdActividadFinanciera,
            };

        }
    }
}
