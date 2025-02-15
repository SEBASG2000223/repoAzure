using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.ObtenerPorId
{
    public class ObtenerActividadPersonaPorIdAD : IObtenerActividadPersonaPorIdAD
    {
        Contexto _elContexto;

        public ObtenerActividadPersonaPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public ActividadPersonaTabla Obtener(int Id)
        {
            ActividadPersonaTabla losClientesEnBaseDeDatos = _elContexto.ActividadPersonaTabla.Where(losClientes => losClientes.IdActividadPersona == Id).FirstOrDefault();
            return losClientesEnBaseDeDatos;
        }
    }
}
