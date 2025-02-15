using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.ObtenerPorId
{
    public class ObtenerArchivoAnalisisPorIdLN : IObtenerArchivoAnalisisPorIdLN
    {
        IObtenerArchivoAnalisisPorIdAD _obtenerArchivoAnalisisPorIdAD;
        public ObtenerArchivoAnalisisPorIdLN()
        {
            _obtenerArchivoAnalisisPorIdAD = new ObtenerArchivoAnalisisPorIdAD();
        }

        public ArchivoAnalisisDto Obtener(int id)
        {
            ArchivoAnalisisTabla ArchivoEnBaseDeDatos = _obtenerArchivoAnalisisPorIdAD.Obtener(id);
            ArchivoAnalisisDto elArchivoAMostrar = ConvertirArchivoAMostrar(ArchivoEnBaseDeDatos);
            return elArchivoAMostrar;
        }

        private ArchivoAnalisisDto ConvertirArchivoAMostrar(ArchivoAnalisisTabla inventarioEnBaseDeDatos)
        {
            return new ArchivoAnalisisDto
            {
                IdArchivo = inventarioEnBaseDeDatos.IdArchivo,
                Nombre = inventarioEnBaseDeDatos.Nombre,
                TextoDelArchivo = inventarioEnBaseDeDatos.TextoDelArchivo,
                Fuente = inventarioEnBaseDeDatos.Fuente,
                FechaDeRegistro = inventarioEnBaseDeDatos.FechaDeRegistro.ToString("dd-MM-yyyy hh:mm tt")
            };
        }
    }
}
