using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.Personas.Listar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.Personas.Listar
{
    public class ListarPersonasLN : IListarPersonasLN
    {
        IListarPersonasAD _listarPersonasAD;
        IConvertirAPersonasDto _convertirAPersonasDto;

        public ListarPersonasLN()
        {
            _listarPersonasAD = new ListarPersonasAD();
            _convertirAPersonasDto = new ConvertirAPersonasDto();
        }

        public List<PersonasDto> Listar()
        {
            List<PersonasDto> laListaDePersonas = _listarPersonasAD.Listar();
            return laListaDePersonas;
        }

        private List<PersonasDto> ObtenerLaListaConvertida(List<PersonasTabla> laListaDePersonas)
        {
            List<PersonasDto> laListaDeNombres = new List<PersonasDto>();
            foreach(PersonasTabla laPersona in laListaDePersonas)
            {
                laListaDeNombres.Add(_convertirAPersonasDto.ConvertirObjetoAPersonasDto(laPersona));
            }
            return laListaDeNombres;
        }
    }
}
