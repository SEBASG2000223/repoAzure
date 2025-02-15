using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.CambiarEstado;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.CambiarEstado;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.CambiarEstado;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.CambiarEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.Personas.CambiarEstado
{
    public class CambiarEstadoPersonasLN : ICambiarEstadoPersonasLN
    {
        ICambiarEstadoPersonasAD _cambiarEstado;

        public CambiarEstadoPersonasLN(IFecha fecha)
        {
            _cambiarEstado = new CambiarEstadoPersonasAD(fecha);
        }
        public async Task<bool> CambiarEstado(int idPersona, bool nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(idPersona, nuevoEstado);
        }
    }
}
