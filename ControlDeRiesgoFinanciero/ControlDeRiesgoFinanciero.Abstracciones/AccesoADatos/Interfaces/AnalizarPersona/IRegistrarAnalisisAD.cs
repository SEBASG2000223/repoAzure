using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona
{
    public interface IRegistrarAnalisisAD
    {
        Task<int> Registrar(AnalizarPersonaTabla analisisARegistrar);
    }
}
