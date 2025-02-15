using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Editar
{
    public interface IEditarPalabraClaveLN
    {
       Task<int> Editar(PalabrasClaveDto laPalabraEnVista);
    }
}
