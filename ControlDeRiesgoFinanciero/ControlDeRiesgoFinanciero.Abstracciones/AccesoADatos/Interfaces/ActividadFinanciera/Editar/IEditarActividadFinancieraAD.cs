using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Editar
{
    public interface IEditarActividadFinancieraAD
    {
        Task<int> Actualizar(ActividadFinancieraTabla laActividadParaActualizar);
    }
}
