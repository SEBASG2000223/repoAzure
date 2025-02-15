using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Listar
{
    public class ListarPalabraClaveAD : IListarPalabraClaveAD
    {
        Contexto _elContexto;

        public ListarPalabraClaveAD()
        {
            _elContexto = new Contexto();
        }

        public List<PalabrasClaveDto> Listar()
        {
            List<PalabrasClaveDto> laListaDePalabras = (from laPalabra in _elContexto.PalabrasClaveTabla
                                                        select new PalabrasClaveDto
                                                   {
                                                       IdPalabra = laPalabra.IdPalabra,
                                                       Palabra = laPalabra.Palabra,
                                                       Orden = laPalabra.Orden,
                                                       FechaDeModificacion = laPalabra.FechaDeModificacion.ToString(),
                                                       FechaDeRegistro = laPalabra.FechaDeRegistro.ToString(),
                                                       Estado = laPalabra.Estado
                                                   }).ToList();
            return laListaDePalabras;
        }
    }
}

