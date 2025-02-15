using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.BitacoraEventos.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.BitacoraEventos.Listar
{
    public class ListarBitacoraEventosAD : IListarBitacoraEventosAD
    {
        Contexto _elContexto;

        public ListarBitacoraEventosAD()
        {
            _elContexto = new Contexto();
        }
        public List<BitacoraEventosDto> Listar()
        {
            List<BitacoraEventosDto> laListaDeBitacora = (from bitacora in _elContexto.BitacoraEventosTabla
                                                              select new BitacoraEventosDto
                                                              {
                                                                  IdEvento = bitacora.IdEvento,
                                                                  TablaDeEvento = bitacora.TablaDeEvento,
                                                                  TipoDeEvento = bitacora.TipoDeEvento,
                                                                  FechaDeEvento = bitacora.FechaDeEvento,
                                                                  DescripcionDeEvento = bitacora.DescripcionDeEvento,
                                                                  StackTrace = bitacora.StackTrace,
                                                                  DatosAnteriores = bitacora.DatosAnteriores,
                                                                  DatosPosteriores = bitacora.DatosPosteriores
                                                              }).ToList();
            return laListaDeBitacora;
        }
    }
}
