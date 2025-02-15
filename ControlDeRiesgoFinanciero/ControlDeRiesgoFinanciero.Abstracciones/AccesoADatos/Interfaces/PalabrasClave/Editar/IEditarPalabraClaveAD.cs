using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Editar
{
    public interface IEditarPalabraClaveAD
    {
        Task<int> Editar(PalabrasClaveTabla laPalabraParaActualizar);
    }
}
