using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.ArchivoAnalisis
{
    public class ConvertirArchivoAnalisisDtoAArchivoAnalisisTabla : IConvertirArchivoAnalisisDtoAArchivoAnalisisTabla
    {
        IFecha _fecha;

        public ConvertirArchivoAnalisisDtoAArchivoAnalisisTabla()
        {
            _fecha = new Fecha();
        }

        public ArchivoAnalisisTabla Convertir(ArchivoAnalisisDto losArchivos)
        {
            return new ArchivoAnalisisTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                IdArchivo = losArchivos.IdArchivo,
                Nombre = losArchivos.Nombre,
                TextoDelArchivo = losArchivos.TextoDelArchivo,
                Fuente = losArchivos.Fuente
            };
        }
    }
}
