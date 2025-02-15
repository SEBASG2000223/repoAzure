using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.AnalizarPersona.Registrar
{
    public class RegistrarAnalisisAD : IRegistrarAnalisisAD
    {
        Contexto _elContexto;
        public RegistrarAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(AnalizarPersonaTabla analisisARegistrar)
        {
            try
            {
                _elContexto.AnalizarPersonaTabla.Add(analisisARegistrar);
                EntityState estado = _elContexto.Entry(analisisARegistrar).State = System.Data.Entity.EntityState.Added;
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
