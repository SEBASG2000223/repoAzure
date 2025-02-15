using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Registrar
{
    public interface IRegistrarPersonasLN
    {
        Task<int> Guardar(PersonasDto modelo);
    }
}
