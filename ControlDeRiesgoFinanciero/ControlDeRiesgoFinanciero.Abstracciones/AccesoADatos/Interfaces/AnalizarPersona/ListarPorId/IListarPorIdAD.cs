using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona.ListarPorId
{
    public interface IListarPorIdAD
    {
        List<AnalizarPersonaDto> Listar(int IdPersona);
    }
}
