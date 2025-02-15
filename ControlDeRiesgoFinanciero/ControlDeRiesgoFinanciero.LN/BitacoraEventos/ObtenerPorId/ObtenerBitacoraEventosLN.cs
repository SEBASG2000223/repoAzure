using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.BitacoraEventos.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.AccesoADatos.BitacoraEventos.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.BitacoraEventos.ObtenerPorId
{
    public class ObtenerBitacoraEventosLN : IObtenerBitacoraEventosLN
    {

        IObtenerBitacoraEventosPorIdAD _obtenerBitacoraEventos;
        public ObtenerBitacoraEventosLN()
        {
            _obtenerBitacoraEventos = new ObtenerBitacoraEventosPorIdAD();
        }
        public BitacoraEventosDto Obtener(int id)
        {
            BitacoraEventosTabla BitacoraEnBaseDeDatos = _obtenerBitacoraEventos.Obtener(id);
            BitacoraEventosDto laBitacoraAMostrar = ConvertirABitacoraAMostrar(BitacoraEnBaseDeDatos);
            return laBitacoraAMostrar;
        }
        private BitacoraEventosDto ConvertirABitacoraAMostrar(BitacoraEventosTabla BitacoraEnBaseDeDatos)
        {
            return new BitacoraEventosDto
            {

                IdEvento = BitacoraEnBaseDeDatos.IdEvento,
                TablaDeEvento = BitacoraEnBaseDeDatos.TablaDeEvento,
                TipoDeEvento = BitacoraEnBaseDeDatos.TipoDeEvento,
                FechaDeEvento = BitacoraEnBaseDeDatos.FechaDeEvento,
                DescripcionDeEvento = BitacoraEnBaseDeDatos.DescripcionDeEvento,
                StackTrace = BitacoraEnBaseDeDatos.StackTrace,
                DatosAnteriores = BitacoraEnBaseDeDatos.DatosPosteriores,
                DatosPosteriores = BitacoraEnBaseDeDatos.DatosPosteriores,

            };
        }
    }
}
