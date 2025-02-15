using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.CambiarEstado;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.CambiarEstado;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.LN.General;
using ControlDeRiesgoFinanciero.LN.Personas.CambiarEstado;
using ControlDeRiesgoFinanciero.LN.Personas.Editar;
using ControlDeRiesgoFinanciero.LN.Personas.Listar;
using ControlDeRiesgoFinanciero.LN.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.Personas.Registrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class PersonasController : Controller
    {
        IListarPersonasLN _listarPersonas;
        IRegistrarPersonasLN _registrarPersonas;
        IObtenerPersonasPorIdLN _obtenerPersonaPorId;
        IEditarPersonasLN _editarPersonas;
        ICambiarEstadoPersonasLN _cambiarEstado;
        IFecha _fecha;
        IRegistrarBitacoraEventosLN _registrarBitacora;

        public PersonasController()
        {
            _listarPersonas = new ListarPersonasLN();
            _registrarPersonas = new RegistrarPersonasLN();
            _obtenerPersonaPorId = new ObtenerPersonasPorIdLN();
            _editarPersonas = new EditarPersonasLN();
            _fecha = new Fecha();
            _cambiarEstado = new CambiarEstadoPersonasLN(_fecha);
            _registrarBitacora = new RegistrarBitacoraEventosLN();
        }

        [Authorize(Roles = "Administrador, Analista")]

        // GET: Personas
        public ActionResult ListarPersonas()
        {
            List<PersonasDto> laListaDePersonas = _listarPersonas.Listar();
            return View(laListaDePersonas);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: Personas/Details/5
        public ActionResult DetallesPersona(int id)
        {
            PersonasDto persona = _obtenerPersonaPorId.Obtener(id);
            return View(persona);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: Personas/Create
        public ActionResult RegistrarPersonas()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: Personas/Create
        [HttpPost]
        public async Task<ActionResult> RegistrarPersonas(PersonasDto modeloDeLaPersona)
        {
            try
            {
                var personaExistente = _listarPersonas.Listar()
                    .FirstOrDefault(laIdentificacion => laIdentificacion.IdentificacionPersona == modeloDeLaPersona.IdentificacionPersona);

                if (personaExistente != null)
                {
                    ViewBag.MensajeDeError = "La identificación ingresada ya está registrada.";
                    return View(modeloDeLaPersona);
                }

             
                int cantidadDeDatosGuardados = await _registrarPersonas.Guardar(modeloDeLaPersona);
              
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PERSONAS_TABLA",
                    TipoDeEvento = "Registrar",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Se registro una nueva persona",
                    DatosAnteriores = "Vacio",
                    DatosPosteriores = $"Nombre: {modeloDeLaPersona.NombrePersona}",
                    StackTrace = ""
                });
                TempData["Alerta"] = " ";
                return RedirectToAction("ListarPersonas");
            }
            catch(Exception ex)
            {
                
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PERSONAS_TABLA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Error al registrar una nueva persona",
                    DatosAnteriores = "",
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace
                });
                TempData["Alerta"] = "Error al crear el registro: ";
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: Personas/Edit/5
        public ActionResult EditarPersonas(int id)
        {
            PersonasDto elNombre = _obtenerPersonaPorId.Obtener(id);
            return View(elNombre);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: Personas/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditarPersonas(PersonasDto laPersona)
        {
            try
            {
              
                var personaAnterior = _listarPersonas.Listar()
                    .FirstOrDefault(a => a.IdPersona == laPersona.IdPersona);

                if (personaAnterior == null)
                {
                    ViewBag.mensaje = "La persona no fue encontrada en la base de datos.";
                    return View(laPersona);
                }

             
                int cantidadDeDatosEditados = await _editarPersonas.Editar(laPersona);

                if (cantidadDeDatosEditados > 0)
                {

                    await _registrarBitacora.Registrar(new BitacoraEventosDto
                    {
                        TablaDeEvento = "PERSONAS_TABLA",
                        TipoDeEvento = "Editar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = "Se realizó una edición en los datos de una persona.",
                        DatosAnteriores = $"Nombre: {personaAnterior.NombrePersona}\n" +
                      $"Primer Apellido: {personaAnterior.PrimerApellidoPersona}\n" +
                      $"Segundo Apellido: {personaAnterior.SegundoApellidoPersona}\n" +
                      $"Teléfono: {personaAnterior.Telefono}\n" +
                      $"Correo: {personaAnterior.CorreoElectronico}\n" +
                      $"Dirección: {personaAnterior.Direccion}\n" +
                      $"Estado: {personaAnterior.Estado}",
                       DatosPosteriores = $"Nombre: {laPersona.NombrePersona}\n" +
                       $"Primer Apellido: {laPersona.PrimerApellidoPersona}\n" +
                       $"Segundo Apellido: {laPersona.SegundoApellidoPersona}\n" +
                       $"Teléfono: {laPersona.Telefono}\n" +
                       $"Correo: {laPersona.CorreoElectronico}\n" +
                       $"Dirección: {laPersona.Direccion}\n" +
                       $"Estado: {laPersona.Estado}",
                        StackTrace = string.Empty
                    });


                    return RedirectToAction("ListarPersonas");
                }

              
                ViewBag.mensaje = "No se realizaron cambios en los datos.";
                return View(laPersona);
            }
            catch (Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PERSONAS_TABLA",
                    TipoDeEvento = "ERROR",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error al editar la persona",
                    DatosAnteriores = "",
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace
                });

                ViewBag.mensaje = "Ocurrió un error inesperado, por favor, intente nuevamente.";
                ViewBag.error = ex.Message;
                return View(laPersona);
            }
        }


        [Authorize(Roles = "Administrador, Analista")]
        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Activar(int id)
        {
            try
            {
                bool resultado = await _cambiarEstado.CambiarEstado(id, true);

                if (resultado)
                {
                    await _registrarBitacora.Registrar(new BitacoraEventosDto
                    {
                        TablaDeEvento = "PERSONAS_TABLA",
                        TipoDeEvento = "Activar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = $"Se reactivó la persona",
                        DatosAnteriores = $"Estado: Inactivo",
                        DatosPosteriores = $"Estado: Activo",
                        StackTrace = ""
                    });
                    return RedirectToAction("ListarPersonas");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo activar la persona.";
                    return RedirectToAction("ListarPersonas");
                }
            }
            catch (Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PERSONAS_TABLA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error al activar la persona",
                    DatosAnteriores = $"",
                    DatosPosteriores = $"",
                    StackTrace = ex.StackTrace
                });
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return RedirectToAction("ListarPersonas");
            }
        }

        public async Task<ActionResult> Inactivar(int id)
        {
            try
            {
                bool resultado = await _cambiarEstado.CambiarEstado(id, false);

                if (resultado)
                {
                    
                    await _registrarBitacora.Registrar(new BitacoraEventosDto
                    {
                        TablaDeEvento = "PERSONAS_TABLA",
                        TipoDeEvento = "Inactivar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = $"Se inactivo la persona",
                        DatosAnteriores = $"Estado: Activo",
                        DatosPosteriores = $"Estado: Inactivo",
                        StackTrace = ""
                    });
                    return RedirectToAction("ListarPersonas");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo inactivar la persona.";
                    return RedirectToAction("ListarPersonas");
                }
            }
            catch (Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PERSONAS_TABLA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error al inactivar la persona",
                    DatosAnteriores = $"",
                    DatosPosteriores = $"",
                    StackTrace = ex.StackTrace
                });
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return RedirectToAction("ListarPersonas");
            }
        }
    }
}
