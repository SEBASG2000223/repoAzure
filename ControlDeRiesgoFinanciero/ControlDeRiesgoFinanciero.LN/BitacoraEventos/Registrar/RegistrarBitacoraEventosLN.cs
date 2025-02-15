using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.AccesoADatos.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar
{
    public class RegistrarBitacoraEventosLN : IRegistrarBitacoraEventosLN
    {
        IRegistrarBitacoraEventosAD _registrarBitacoraEventosAD;
        IFecha _fecha;

        public RegistrarBitacoraEventosLN()
        {
            _fecha = new Fecha();
            _registrarBitacoraEventosAD = new RegistrarBitacoraEventosAD();

        }
        public async Task<int> Registrar(BitacoraEventosDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _registrarBitacoraEventosAD.Registrar(ConvertirObjetoBitacoraTabla(modelo));

            return cantidadDeDatosAlmacenados;
        }
        private BitacoraEventosTabla ConvertirObjetoBitacoraTabla(BitacoraEventosDto laBitacora)
        {
            return new BitacoraEventosTabla
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
