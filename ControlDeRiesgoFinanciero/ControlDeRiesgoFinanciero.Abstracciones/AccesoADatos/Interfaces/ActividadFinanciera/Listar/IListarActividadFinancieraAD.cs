using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Listar
{
    public interface IListarActividadFinancieraAD
    {
        List<ActividadFinancieraDto> Listar();
    }
}
