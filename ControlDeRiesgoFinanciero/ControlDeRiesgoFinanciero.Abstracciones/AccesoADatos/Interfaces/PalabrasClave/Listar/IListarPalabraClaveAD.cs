using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Listar
{
    public interface IListarPalabraClaveAD
    {
        List<PalabrasClaveDto> Listar();
    }
}
