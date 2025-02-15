using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.Listar
{
    public class ListarArchivoAnalisisLN : IListarArchivoAnalisisLN
    {
        IListarArchivoAnalisisAD _listarArchivoAnalisisAD;

        public ListarArchivoAnalisisLN()
        {
            _listarArchivoAnalisisAD = new ListarArchivoAnalisisAD();
        }

        public List<ArchivoAnalisisDto> Listar()
        {
            List<ArchivoAnalisisDto> listaDeArchivos = _listarArchivoAnalisisAD.Listar();
            return listaDeArchivos;
        }

        private List<ArchivoAnalisisDto> ObtenerLaListaConvertida(List<ArchivoAnalisisTabla> listaDeArchivos)
        {
            List<ArchivoAnalisisDto> laListaDeArchivos = new List<ArchivoAnalisisDto>();
            foreach (ArchivoAnalisisTabla archivo in listaDeArchivos)
            {
                laListaDeArchivos.Add(ConvertirArchivoAnalisisADto(archivo));
            }
            return laListaDeArchivos;
        }

        private ArchivoAnalisisDto ConvertirArchivoAnalisisADto(ArchivoAnalisisTabla elArchivo)
        {
            return new ArchivoAnalisisDto
            {
                FechaDeRegistro = elArchivo.FechaDeRegistro.ToString("dd-MM-yyyy hh:mm tt"),
                IdArchivo = elArchivo.IdArchivo,
                Nombre = elArchivo.Nombre,
                TextoDelArchivo = elArchivo.TextoDelArchivo,
                Fuente = elArchivo.Fuente
            };
        }
    }
}
