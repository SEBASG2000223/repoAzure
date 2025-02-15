using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.ObtenerPorId
{
    public class ObtenerPalabraClavePorIdAD : IObtenerPalabraClavePorIdAD
    {
        Contexto _elContexto;

        public ObtenerPalabraClavePorIdAD()
        {
            _elContexto = new Contexto();
        }

        public PalabrasClaveTabla Obtener(int IdPalabra)
        {
            PalabrasClaveTabla laPalabraEnBD = _elContexto.PalabrasClaveTabla.Where(laPalabra => laPalabra.IdPalabra == IdPalabra).FirstOrDefault();
            return laPalabraEnBD;
        }
    }
}
