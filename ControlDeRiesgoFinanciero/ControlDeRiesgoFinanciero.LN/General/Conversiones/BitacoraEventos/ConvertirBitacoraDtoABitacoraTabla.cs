using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.General.Conversiones.BitacoraEventos
{
    public class ConvertirBitacoraDtoABitacoraTabla : IConvertirBitacoraDtoABitacoraTabla
    {
        IFecha _fecha;

        public ConvertirBitacoraDtoABitacoraTabla()
        {
            _fecha = new Fecha();
        }
        public BitacoraEventosTabla Convertir(BitacoraEventosDto laBitacora)
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
                DatosPosteriores = laBitacora.DatosPosteriores

            };


        }
    }
}
