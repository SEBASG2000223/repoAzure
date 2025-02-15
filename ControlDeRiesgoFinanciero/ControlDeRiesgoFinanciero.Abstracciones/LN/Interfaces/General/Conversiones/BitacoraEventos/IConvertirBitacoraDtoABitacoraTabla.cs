using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.BitacoraEventos
{
    public interface IConvertirBitacoraDtoABitacoraTabla
    {
        BitacoraEventosTabla Convertir(BitacoraEventosDto laBitacora);

    }
}
