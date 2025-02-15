using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.BitacoraEventos.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.BitacoraEventos.ObtenerPorId
{
    public class ObtenerBitacoraEventosPorIdAD : IObtenerBitacoraEventosPorIdAD
    {
        Contexto _elContexto;

        public ObtenerBitacoraEventosPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public BitacoraEventosTabla Obtener(int Id)
        {
            BitacoraEventosTabla laBitacoraEnBaseDeDatos = _elContexto.BitacoraEventosTabla.Where(laBitacora => laBitacora.IdEvento == Id).FirstOrDefault();
            return laBitacoraEnBaseDeDatos;
        }
    }
}
