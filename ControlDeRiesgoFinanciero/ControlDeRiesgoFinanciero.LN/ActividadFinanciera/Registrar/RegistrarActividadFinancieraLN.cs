using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadFinanciera.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using ControlDeRiesgoFinanciero.AccesoADatos.ActividadFinanciera.Registrar;
using ControlDeRiesgoFinanciero.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Registrar
{
    public class RegistrarActividadFinancieraLN : IRegistrarActividadFinancieraLN
    {
        IRegistrarActividadFinancieraAD _registrarActividadAD;
        IFecha _fecha;

        public RegistrarActividadFinancieraLN()
        {
            _fecha = new Fecha();
            _registrarActividadAD = new RegistrarActividadFinancieraAD();
        }

        public async Task<int> Guardar(ActividadFinancieraDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _registrarActividadAD.Guardar(ConvertirObjetoInventarioTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        private ActividadFinancieraTabla ConvertirObjetoInventarioTabla(ActividadFinancieraDto laActividad)
        {
            return new ActividadFinancieraTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                Estado = laActividad.Estado,
                NivelDeRiesgo = laActividad.NivelDeRiesgo,
                DescripcionActividadFinanciera = laActividad.DescripcionActividadFinanciera,
                NombreActividadFinanciera = laActividad.NombreActividadFinanciera,
                IdActividadFinanciera = laActividad.IdActividadFinanciera

            };
        }
    }
}
