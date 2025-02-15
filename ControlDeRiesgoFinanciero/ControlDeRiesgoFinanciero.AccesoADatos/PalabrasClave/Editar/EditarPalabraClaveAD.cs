using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Editar
{
    public class EditarPalabraClaveAD : IEditarPalabraClaveAD
    {
        Contexto _elContexto;

        public EditarPalabraClaveAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(PalabrasClaveTabla laPalabraParaActualizar)
        {
            PalabrasClaveTabla laPalabraEnBD = _elContexto.PalabrasClaveTabla.Where(laPalabra => laPalabra.IdPalabra == laPalabraParaActualizar.IdPalabra).FirstOrDefault();

            laPalabraEnBD.Palabra = laPalabraParaActualizar.Palabra;
            laPalabraEnBD.Orden = laPalabraParaActualizar.Orden;
            laPalabraEnBD.FechaDeModificacion = laPalabraParaActualizar.FechaDeModificacion;
            laPalabraEnBD.IdPalabra = laPalabraParaActualizar.IdPalabra;
          

            EntityState estado = _elContexto.Entry(laPalabraEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
