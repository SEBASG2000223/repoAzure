using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Detalles
{
    public interface IDetallesArchivoAnalisisAD
    {
        List<ArchivoAnalisisDto> ListarDetallesDelArchivo(int id);
    }
}
