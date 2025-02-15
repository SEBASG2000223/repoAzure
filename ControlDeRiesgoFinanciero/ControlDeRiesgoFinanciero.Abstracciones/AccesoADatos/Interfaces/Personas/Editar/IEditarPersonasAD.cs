using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Editar
{
    public interface IEditarPersonasAD
    {
        Task<int> Editar(PersonasTabla laPersonasParaEditar);
    }
}
