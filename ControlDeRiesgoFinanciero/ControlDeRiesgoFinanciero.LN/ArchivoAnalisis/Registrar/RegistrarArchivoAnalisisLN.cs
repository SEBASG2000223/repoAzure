using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ArchivoAnalisis.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ArchivoAnalisis.Registrar;
using ControlDeRiesgoFinanciero.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.Registrar
{
    public class RegistrarArchivoAnalisisLN : IRegistrarArchivoAnalisisLN
    {
        IRegistrarArchivoAnalisisAD _registrarArchivoAnalisisAD;
        IFecha _fecha;

        public RegistrarArchivoAnalisisLN()
        {
            _fecha = new Fecha();
            _registrarArchivoAnalisisAD = new RegistrarArchivoAnalisisAD();

        }
        public async Task<int> Registrar(ArchivoAnalisisDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _registrarArchivoAnalisisAD.Registrar(ConvertirObjetoArchivoAnalisisTabla(modelo));

            return cantidadDeDatosAlmacenados;
        }
        private ArchivoAnalisisTabla ConvertirObjetoArchivoAnalisisTabla(ArchivoAnalisisDto elArchivo)
        {
            return new ArchivoAnalisisTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                IdArchivo = elArchivo.IdArchivo,
                Nombre = elArchivo.Nombre,
                TextoDelArchivo = elArchivo.TextoDelArchivo,
                Fuente = elArchivo.Fuente
            };
        }
    }
}
