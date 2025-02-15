using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Registrar
{
    public class RegistrarActividadPersonaAD : IRegistrarActividadPersonaAD
    {
        Contexto _elContexto;
        public RegistrarActividadPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ActividadPersonaTabla actividadesARegistrar)
        {
            try
            {
                _elContexto.ActividadPersonaTabla.Add(actividadesARegistrar);
                EntityState estado = _elContexto.Entry(actividadesARegistrar).State = System.Data.Entity.EntityState.Added;
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
