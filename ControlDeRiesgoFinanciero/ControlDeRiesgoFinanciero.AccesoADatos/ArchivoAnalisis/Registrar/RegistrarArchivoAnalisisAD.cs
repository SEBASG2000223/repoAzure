using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Registrar
{
    public class RegistrarArchivoAnalisisAD : IRegistrarArchivoAnalisisAD
    {
        Contexto _elContexto;
        public RegistrarArchivoAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ArchivoAnalisisTabla archivoARegistrar)
        {
            try
            {
                _elContexto.ArchivoAnalisisTabla.Add(archivoARegistrar);
                EntityState estado = _elContexto.Entry(archivoARegistrar).State = System.Data.Entity.EntityState.Added;
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
