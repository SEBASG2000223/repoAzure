using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.ObtenerPorId
{
    public interface IObtenerActividadFinancieraPorID
    {
        ActividadFinancieraTabla Obtener(int Id);
    }
}
