using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Detalles;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Detalles
{
    public class DetallesArchivoAnalisisAD : IDetallesArchivoAnalisisAD
    {
        Contexto _elContexto;

        public DetallesArchivoAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public List<ArchivoAnalisisDto> ListarDetallesDelArchivo(int id)
        {
            List<ArchivoAnalisisDto> laListaDeDetalles = (from elArchivo in _elContexto.ArchivoAnalisisTabla
                                                          where elArchivo.IdArchivo == id
                                                          select new ArchivoAnalisisDto 
                                                          {
                                                              IdArchivo = elArchivo.IdArchivo,
                                                              Nombre = elArchivo.Nombre,
                                                              TextoDelArchivo = elArchivo.TextoDelArchivo,
                                                              Fuente = elArchivo.Fuente,
                                                              FechaDeRegistro = elArchivo.FechaDeRegistro.ToString()
                                                          }).ToList();
            return laListaDeDetalles;
        }
    }
}
