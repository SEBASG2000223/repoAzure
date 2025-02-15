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
    public class ConvertirAPalabrasClaveDto : IConvertirAPalabrasClaveDto
    {
        public PalabrasClaveDto ConvertirObjetoAPalabrasClaveDto(PalabrasClaveTabla laPalabra)
        {
            return new PalabrasClaveDto
            {
                IdPalabra = laPalabra.IdPalabra,
                Palabra = laPalabra.Palabra,
                Orden = laPalabra.Orden,
                FechaDeRegistro = laPalabra.FechaDeRegistro.ToString("dd - MM - yyyy hh: mm tt"),
                FechaDeModificacion = laPalabra.FechaDeModificacion.ToString("dd - MM - yyyy hh: mm tt")
            };
        }
    }
}
