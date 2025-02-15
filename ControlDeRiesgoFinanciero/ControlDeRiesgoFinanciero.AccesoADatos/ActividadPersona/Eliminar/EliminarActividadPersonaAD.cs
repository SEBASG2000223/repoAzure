using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Eliminar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Eliminar
{
    public class EliminarActividadPersonaAD : IEliminarActividadPersonaAD
    {
        Contexto _elContexto;
        public EliminarActividadPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Desactivar(ActividadPersonaTabla lasActividadesPersonasADesactivar)
        {
            ActividadPersonaTabla lasActividadesEnBaseDeDatos = _elContexto.ActividadPersonaTabla.Where(lasActividadesPersona => lasActividadesPersona.IdActividadPersona == lasActividadesPersonasADesactivar.IdActividadPersona).FirstOrDefault();

            lasActividadesEnBaseDeDatos.FechaDeModificacion = lasActividadesPersonasADesactivar.FechaDeModificacion;
            lasActividadesEnBaseDeDatos.Estado = lasActividadesPersonasADesactivar.Estado;
            lasActividadesEnBaseDeDatos.IdActividadFinanciera = lasActividadesPersonasADesactivar.IdActividadFinanciera;
            lasActividadesEnBaseDeDatos.IdActividadPersona = lasActividadesPersonasADesactivar.IdActividadPersona;
            lasActividadesEnBaseDeDatos.IdPersona = lasActividadesPersonasADesactivar.IdPersona;
            




            EntityState estado = _elContexto.Entry(lasActividadesEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
