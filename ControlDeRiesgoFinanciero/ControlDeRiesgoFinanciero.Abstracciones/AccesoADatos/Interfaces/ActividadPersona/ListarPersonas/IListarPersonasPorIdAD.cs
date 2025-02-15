using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ListarPersonas
{
    public interface IListarPersonasPorIdAD
    {
        List<ActividadPersonaDto> ListarActividades(int idPersona);
    }
}
