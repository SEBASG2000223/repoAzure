using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.ObtenerPorId
{
    public interface IObtenerPalabraClavePorIdLN
    {
        PalabrasClaveDto Obtener(int IdPalabra);
    }
}
