using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.ObtenerPorId
{
    public class ObtenerActividadFinancieraPorID : IObtenerActividadFinancieraPorID
    {
        Contexto _elContexto;

        public ObtenerActividadFinancieraPorID()
        {
            _elContexto = new Contexto();
        }

        public ActividadFinancieraTabla Obtener(int Id)
        {
            ActividadFinancieraTabla laActividadEnBaseDeDatos = _elContexto.ActividadFinancieraTabla.Where(laActividad => laActividad.IdActividadFinanciera== Id).FirstOrDefault();
            return laActividadEnBaseDeDatos;
        }
    }
}
