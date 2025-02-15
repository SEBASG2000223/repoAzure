using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.CambiarEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.CambiarEstado
{
    public interface ICambiarEstadoPersonasLN
    {
        Task<bool> CambiarEstado(int idPersona, bool nuevoEstado);
    }
}
