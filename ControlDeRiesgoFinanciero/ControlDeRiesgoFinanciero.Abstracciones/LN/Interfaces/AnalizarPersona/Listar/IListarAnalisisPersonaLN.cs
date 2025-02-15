using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Listar
{
    public interface IListarAnalisisPersonaLN
    {
        List<ListarAnalisisPersonaDto> Listar();
    }
}
