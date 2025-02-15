using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Registrar
{
    public class RegistrarActividadFinancieraAD : IRegistrarActividadFinancieraAD
    {
        Contexto _elContexto;
        public RegistrarActividadFinancieraAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Guardar(ActividadFinancieraTabla laActividadAGuardar)
        {
            try
            {
                _elContexto.ActividadFinancieraTabla.Add(laActividadAGuardar);
                EntityState estado = _elContexto.Entry(laActividadAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
