using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Listar
{
    public class ListarArchivoAnalisisAD : IListarArchivoAnalisisAD
    {
        Contexto _elContexto;

        public ListarArchivoAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public List<ArchivoAnalisisDto> Listar()
        {
            List<ArchivoAnalisisDto> laListaDeArchivos = (from elArchivo in _elContexto.ArchivoAnalisisTabla
                                                                 select new ArchivoAnalisisDto
                                                                 {
                                                                     IdArchivo = elArchivo.IdArchivo,
                                                                     Nombre = elArchivo.Nombre,
                                                                     TextoDelArchivo = elArchivo.TextoDelArchivo,
                                                                     Fuente = elArchivo.Fuente,
                                                                     FechaDeRegistro = elArchivo.FechaDeRegistro.ToString()
                                                                 }).ToList();
            return laListaDeArchivos;
        }
    }
}
