using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.CambiarEstado
{
    public interface ICambiarEstadoPersonasAD
    {
        Task<bool> CambiarEstado(int idPersona, bool nuevoEstado);
    }
}
