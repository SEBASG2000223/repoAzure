using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.ListarActividadesNoRegistradas
{
    public interface IListarActividadesNoRegistradasLN
    {
        List<ActividadPersonaDto> ListarPersonasNoRegistradas(int idPersona);
    }
}
