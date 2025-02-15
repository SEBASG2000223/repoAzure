using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.ObtenerPorId
{
    public interface IObtenerBitacoraEventosLN
    {

        BitacoraEventosDto Obtener(int id);
    }
}
