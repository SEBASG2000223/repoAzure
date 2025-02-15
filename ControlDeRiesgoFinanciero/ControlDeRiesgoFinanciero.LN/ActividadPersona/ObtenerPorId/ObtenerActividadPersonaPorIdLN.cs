using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadPersona.ObtenerPorId
{
    public class ObtenerActividadPersonaPorIdLN : IObtenerActividadPersonaPorIdLN
    {

        IObtenerActividadPersonaPorIdAD _obtenerActividadPersonaPorIdAD;
        public ObtenerActividadPersonaPorIdLN()
        {
            _obtenerActividadPersonaPorIdAD = new ObtenerActividadPersonaPorIdAD();
        }
        public ActividadPersonaDto Obtener(int id)
        {
            ActividadPersonaTabla ActividadesPersonaEnBaseDeDatos = _obtenerActividadPersonaPorIdAD.Obtener(id);
            ActividadPersonaDto lasActividadesPersonasAMostrar = ConvertirAActividadesPersonasAMostrar(ActividadesPersonaEnBaseDeDatos);
            return lasActividadesPersonasAMostrar;
        }
        private ActividadPersonaDto ConvertirAActividadesPersonasAMostrar(ActividadPersonaTabla ActividadesPersonaEnBaseDeDatos)
        {
            return new ActividadPersonaDto
            {
               
                IdActividadPersona = ActividadesPersonaEnBaseDeDatos.IdActividadPersona,
                IdActividadFinanciera = ActividadesPersonaEnBaseDeDatos.IdActividadFinanciera,
                IdPersona = ActividadesPersonaEnBaseDeDatos.IdPersona,
                Estado = ActividadesPersonaEnBaseDeDatos.Estado

            };
        }
    }
}
