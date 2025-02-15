using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.ListarPorId
{
    public interface IListarPorIdLN
    {
        List<AnalizarPersonaDto> ListarPorId(int idPersona);
    }
}
