using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Listar
{
    public interface IListarPalabraClaveLN
    {
        List<PalabrasClaveDto> Listar();
    }
}
