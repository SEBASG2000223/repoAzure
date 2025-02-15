using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.Personas.ObtenerPorId
{
    public class ObtenerPersonasPorIdAD : IObtenerPersonasPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPersonasPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public PersonasTabla Obtener(int IdPersona)
        {
            PersonasTabla laPersonaEnBD = _elContexto.PersonasTabla.Where(laPersona => laPersona.IdPersona == IdPersona).FirstOrDefault();
            return laPersonaEnBD;
        }
    }
}
