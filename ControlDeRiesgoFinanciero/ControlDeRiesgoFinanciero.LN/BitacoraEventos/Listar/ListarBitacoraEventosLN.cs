using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.BitacoraEventos.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.AccesoADatos.BitacoraEventos.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.BitacoraEventos.Listar
{
    public class ListarBitacoraEventosLN: IListarBitacoraEventosLN
    {
        IListarBitacoraEventosAD _listarBitacoraEventosAD;
        public ListarBitacoraEventosLN()
        {
            _listarBitacoraEventosAD = new ListarBitacoraEventosAD();

        }

        public List<BitacoraEventosDto> Listar()
        {
            List<BitacoraEventosDto> laListaDeBitacora = _listarBitacoraEventosAD.Listar();
            return laListaDeBitacora;
        }
        private List<BitacoraEventosDto> ObtenerLaListaConvertida(List<BitacoraEventosTabla> laLista)
        {
            List<BitacoraEventosDto> laListaDeBitacora = new List<BitacoraEventosDto>();
            foreach (BitacoraEventosTabla laBitacora in laLista)
            {
                laListaDeBitacora.Add(ConvertirObjetoBitacoraDto(laBitacora));
            }
            return laListaDeBitacora;
        }
        private BitacoraEventosDto ConvertirObjetoBitacoraDto(BitacoraEventosTabla laBitacora)
        {
            return new BitacoraEventosDto
            {
                IdEvento = laBitacora.IdEvento,
                TablaDeEvento = laBitacora.TablaDeEvento,
                TipoDeEvento = laBitacora.TipoDeEvento,
                FechaDeEvento = laBitacora.FechaDeEvento,
                DescripcionDeEvento = laBitacora.DescripcionDeEvento,
                StackTrace = laBitacora.StackTrace,
                DatosAnteriores = laBitacora.DatosAnteriores,
                DatosPosteriores = laBitacora.DatosPosteriores,

            };
        }
    }
}
