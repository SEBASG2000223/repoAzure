using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.ObtenerPorId
{
    public interface IObtenerArchivoAnalisisPorIdLN
    {
        ArchivoAnalisisDto Obtener(int id);
    }
}
