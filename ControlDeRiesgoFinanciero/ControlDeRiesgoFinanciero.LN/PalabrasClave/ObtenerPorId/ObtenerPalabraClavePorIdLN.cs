using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.PalabrasClave.ObtenerPorId
{
    public class ObtenerPalabraClavePorIdLN : IObtenerPalabraClavePorIdLN
    {
        IObtenerPalabraClavePorIdAD _obtenerPalabraClave;

        public ObtenerPalabraClavePorIdLN()
        {
            _obtenerPalabraClave = new ObtenerPalabraClavePorIdAD();
        }

        public PalabrasClaveDto Obtener(int IdPalabra)
        {
            PalabrasClaveTabla laPalabraEnBD = _obtenerPalabraClave.Obtener(IdPalabra);
            PalabrasClaveDto laPalabraAMostrar = ConvertirPalabraAMostrar(laPalabraEnBD);
            return laPalabraAMostrar;
        }

        private PalabrasClaveDto ConvertirPalabraAMostrar(PalabrasClaveTabla laPalabraEnBD)
        {
            return new PalabrasClaveDto
            {
                IdPalabra = laPalabraEnBD.IdPalabra,
                Palabra = laPalabraEnBD.Palabra,
                Orden = laPalabraEnBD.Orden,
                FechaDeRegistro = laPalabraEnBD.FechaDeRegistro.ToString(),
                FechaDeModificacion = laPalabraEnBD.FechaDeModificacion.ToString(),
                Estado = laPalabraEnBD.Estado
            };
        }
    }
}
