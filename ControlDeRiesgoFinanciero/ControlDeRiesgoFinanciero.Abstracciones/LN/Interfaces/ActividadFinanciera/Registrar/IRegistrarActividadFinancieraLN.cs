
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Registrar
{
    public interface IRegistrarActividadFinancieraLN
    {
        Task<int> Guardar(ActividadFinancieraDto modelo);
    }
}
