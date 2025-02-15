using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Detalles
{
    public interface IDetallesArchivoAnalisisLN
    {
        List<ArchivoAnalisisDto> Listar(int id);
    }
}
