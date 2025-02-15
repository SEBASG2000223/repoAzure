using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.Personas.Registrar
{
    public class RegistrarPersonasAD : IRegistrarPersonasAD
    {
        Contexto _elContexto;

        public RegistrarPersonasAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Guardar(PersonasTabla laPersonaAGuardar)
        {
            try
            {
                _elContexto.PersonasTabla.Add(laPersonaAGuardar);
                EntityState estado = _elContexto.Entry(laPersonaAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
