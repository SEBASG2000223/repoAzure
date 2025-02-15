using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Detalles;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Detalles;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Detalles;
using ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.Detalles
{
    public class DetallesArchivoAnalisisLN : IDetallesArchivoAnalisisLN
    {
        IDetallesArchivoAnalisisAD _detallesArchivoAnalisisAD;

        public DetallesArchivoAnalisisLN()
        {
            _detallesArchivoAnalisisAD = new DetallesArchivoAnalisisAD();
        }

        public List<ArchivoAnalisisDto> Listar(int id)
        {
            List<ArchivoAnalisisDto> listaDeDetalles = _detallesArchivoAnalisisAD.ListarDetallesDelArchivo(id);
            return listaDeDetalles;
        }
    }
}
