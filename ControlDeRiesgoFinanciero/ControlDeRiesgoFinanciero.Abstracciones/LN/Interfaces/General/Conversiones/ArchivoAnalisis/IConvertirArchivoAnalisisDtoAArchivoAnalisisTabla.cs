using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ArchivoAnalisis
{
    public interface IConvertirArchivoAnalisisDtoAArchivoAnalisisTabla
    {
        ArchivoAnalisisTabla Convertir(ArchivoAnalisisDto losArchivos);
    }
}
