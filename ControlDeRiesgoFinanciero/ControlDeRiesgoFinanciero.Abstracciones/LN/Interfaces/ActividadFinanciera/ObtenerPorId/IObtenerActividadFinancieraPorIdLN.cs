using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.ObtenerPorId
{
    public interface IObtenerActividadFinancieraPorIdLN
    {
        ActividadFinancieraDto Obtener(int id);


    }
}
