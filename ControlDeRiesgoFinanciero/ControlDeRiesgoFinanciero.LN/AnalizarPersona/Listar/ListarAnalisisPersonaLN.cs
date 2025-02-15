using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using ControlDeRiesgoFinanciero.AccesoADatos.AnalizarPersona.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.AnalizarPersona.Listar
{
    public class ListarAnalisisPersonaLN : IListarAnalisisPersonaLN
    {
        IListarAnalisisPersonaAD _listarAnalisisPersonaAD;

        public ListarAnalisisPersonaLN()
        {
            _listarAnalisisPersonaAD = new ListarAnalisisPersonaAD();
        }

        public List<ListarAnalisisPersonaDto> Listar()
        {
            List<ListarAnalisisPersonaDto> listaDeAnalisis = _listarAnalisisPersonaAD.Listar();
            return listaDeAnalisis;
        }
    }
}
