using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Editar
{
    public class EditarActividadFinancieraAD : IEditarActividadFinancieraAD
    {
        Contexto _elContexto;

        public EditarActividadFinancieraAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Actualizar(ActividadFinancieraTabla laActividadParaActualizar)
        {
            ActividadFinancieraTabla laActividadEnBaseDeDatos = _elContexto.ActividadFinancieraTabla.Where(laActividad => laActividad.IdActividadFinanciera == laActividadParaActualizar.IdActividadFinanciera).FirstOrDefault();

            laActividadEnBaseDeDatos.NombreActividadFinanciera = laActividadParaActualizar.NombreActividadFinanciera;
            laActividadEnBaseDeDatos.DescripcionActividadFinanciera = laActividadParaActualizar.DescripcionActividadFinanciera;
            laActividadEnBaseDeDatos.Estado = laActividadParaActualizar.Estado;
            laActividadEnBaseDeDatos.FechaDeModificacion = laActividadParaActualizar.FechaDeModificacion;
            laActividadEnBaseDeDatos.IdActividadFinanciera = laActividadParaActualizar.IdActividadFinanciera;

            EntityState estado = _elContexto.Entry(laActividadEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
