using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.BitacoraEventos.Editar
{
    public class RegistrarBitacoraEventosAD : IRegistrarBitacoraEventosAD
    {
        Contexto _elContexto;
        public RegistrarBitacoraEventosAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Registrar(BitacoraEventosTabla bitacoraARegistrar)
        {
            try
            {
                _elContexto.BitacoraEventosTabla.Add(bitacoraARegistrar);
                EntityState estado = _elContexto.Entry(bitacoraARegistrar).State = System.Data.Entity.EntityState.Added;
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
