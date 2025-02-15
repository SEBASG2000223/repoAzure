using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Listar
{
    public interface IListarPersonasAD
    {
        List<PersonasDto> Listar();
    }
}
