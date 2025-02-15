using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Registrar
{
    public class RegistrarPalabraClaveAD : IRegistrarPalabraClaveAD
    {
        Contexto _elContexto;

        public RegistrarPalabraClaveAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Guardar(PalabrasClaveTabla laPalabraAGuardar)
        {
            try
            {
                _elContexto.PalabrasClaveTabla.Add(laPalabraAGuardar);
                EntityState estado = _elContexto.Entry(laPalabraAGuardar).State = System.Data.Entity.EntityState.Added;
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
