using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.PalabrasClave
{
    public class ConvertirAPalabrasClaveTabla : IConvertirAPalabrasClaveTabla
    {
        IFecha _fecha;

        public ConvertirAPalabrasClaveTabla()
        {
            _fecha = new Fecha();
        }

        public PalabrasClaveTabla ConvertirObjetoAPalabrasClaveTabla(PalabrasClaveDto laPalabra)
        {
            return new PalabrasClaveTabla
            {
                IdPalabra = laPalabra.IdPalabra,
                Palabra = laPalabra.Palabra,
                Orden = laPalabra.Orden,
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                Estado = laPalabra.Estado
            };
        }
    }
}
