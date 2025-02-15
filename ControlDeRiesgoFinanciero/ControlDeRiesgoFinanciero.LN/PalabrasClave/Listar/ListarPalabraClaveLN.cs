using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.PalabrasClave.Listar
{
    public class ListarPalabraClaveLN : IListarPalabraClaveLN
    {
        IListarPalabraClaveAD _listarPalabraClaveAD;
        IConvertirAPalabrasClaveDto _convertirAPalabrasClaveDto;

        public ListarPalabraClaveLN()
        {
            _listarPalabraClaveAD = new ListarPalabraClaveAD();
            _convertirAPalabrasClaveDto = new ConvertirAPalabrasClaveDto();
        }

        public List<PalabrasClaveDto> Listar()
        {
            List<PalabrasClaveDto> laListaDePalabras = _listarPalabraClaveAD.Listar();
            return laListaDePalabras;
        }

        private List<PalabrasClaveDto> ObtenerLaListaConvertida(List<PalabrasClaveTabla> laListaDePalabras)
        {
            List<PalabrasClaveDto> laListaDeOrdenes = new List<PalabrasClaveDto>();
            foreach (PalabrasClaveTabla laPalabra in laListaDePalabras)
            {
                laListaDeOrdenes.Add(_convertirAPalabrasClaveDto.ConvertirObjetoAPalabrasClaveDto(laPalabra));
            }
            return laListaDeOrdenes;
        }
    }
}

