using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Registrar
{
    public interface IRegistrarPalabraClaveLN
    {
        Task<int> Guardar(PalabrasClaveDto modelo);
    }
}
