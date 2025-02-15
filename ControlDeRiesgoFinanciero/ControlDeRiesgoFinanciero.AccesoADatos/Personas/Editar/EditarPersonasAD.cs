using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos.Personas.Editar
{
    public class EditarPersonasAD : IEditarPersonasAD
    {
        Contexto _elContexto;

        public EditarPersonasAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(PersonasTabla laPersonasParaEditar)
        {
            PersonasTabla laPersonaEnBD = _elContexto.PersonasTabla.Where(laPersona => laPersona.IdPersona == laPersonasParaEditar.IdPersona).FirstOrDefault();
            laPersonaEnBD.NombrePersona = laPersonasParaEditar.NombrePersona;
            laPersonaEnBD.PrimerApellidoPersona = laPersonasParaEditar.PrimerApellidoPersona;
            laPersonaEnBD.SegundoApellidoPersona = laPersonasParaEditar.SegundoApellidoPersona;
            laPersonaEnBD.Telefono = laPersonasParaEditar.Telefono;
            laPersonaEnBD.CorreoElectronico = laPersonasParaEditar.CorreoElectronico;
            laPersonaEnBD.Direccion = laPersonasParaEditar.Direccion;
            laPersonaEnBD.FechaDeModificacion = laPersonasParaEditar.FechaDeModificacion;
            laPersonaEnBD.Estado = laPersonasParaEditar.Estado;
            EntityState estado = _elContexto.Entry(laPersonaEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
}
