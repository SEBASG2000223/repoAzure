using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Analizar
{
    public interface IAnalizarPersonaLN
    {
        (string nivelRiesgo, int cantidadPalabrasClave, int cantidadArchivos) RealizarAnalisis(int idPersona);
    }
}
