using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.ObtenerPorId
{
    public class ObtenerArchivoAnalisisPorIdAD : IObtenerArchivoAnalisisPorIdAD
    {
        Contexto _elContexto;

        public ObtenerArchivoAnalisisPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public ArchivoAnalisisTabla Obtener(int Id)
        {
            ArchivoAnalisisTabla losArchivosEnBaseDeDatos = _elContexto.ArchivoAnalisisTabla.Where(losArchivos => losArchivos.IdArchivo == Id).FirstOrDefault();
            return losArchivosEnBaseDeDatos;
        }
    }
}
