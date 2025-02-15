using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Listar
{
    public interface IListarArchivoAnalisisLN
    {
        List<ArchivoAnalisisDto> Listar();
    }
}
