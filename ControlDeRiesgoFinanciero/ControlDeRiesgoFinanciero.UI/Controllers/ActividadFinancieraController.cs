using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.General.Conversiones.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Editar;
using ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.LN.ActividadFinanciera.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Registrar;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.LN.General;
using ControlDeRiesgoFinanciero.LN.General.Conversiones.ActividadFinanciera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class ActividadFinancieraController : Controller
    {
        IListarActividadFinancieraLN _listarActividadFinanciera;
        IRegistrarActividadFinancieraLN _registarActividades;
        IObtenerActividadFinancieraPorIdLN _obtenerPorId;
        IEditarActividadFinancieraLN _editarActividadN;
        ICambiarEstadoLN _cambiarEstado;
        IFecha _fecha;
        IRegistrarBitacoraEventosLN _registrarBitacora;

        public ActividadFinancieraController()
        {
            _listarActividadFinanciera = new ListarActividadFinancieraLN();
            _fecha = new Fecha();
            _registarActividades = new RegistrarActividadFinancieraLN();
            _editarActividadN = new EditarActividadFinancieraLN();
            _obtenerPorId = new ObtenerActividadFinancieraPorIdLN();
            _cambiarEstado = new CambiarEstadoLN(_fecha);
            _registrarBitacora = new RegistrarBitacoraEventosLN();

        }

        [Authorize(Roles = "Administrador")]
        // GET: ActividadFinanciera
        public ActionResult Index()
        {
            ViewBag.Title = "Las Actividades Financieras";
            List<ActividadFinancieraDto> laListaDeActividad = _listarActividadFinanciera.Listar();
            return View(laListaDeActividad);
        }

        [Authorize(Roles = "Administrador")]
        // GET: ActividadFinanciera/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // GET: ActividadFinanciera/Create
        public ActionResult Create()
        {
       
            var modeloDeActividad = new ActividadFinancieraDto
            {
                Estado = true 
            };
            return View(modeloDeActividad);
        }

        [Authorize(Roles = "Administrador")]
        // POST: ActividadFinanciera/Create
        [HttpPost]
        public async Task<ActionResult> Create(ActividadFinancieraDto modeloDeActividad)
        {
            try
            {
                var existeActividad = _listarActividadFinanciera.Listar();
                bool actividadDuplicada = existeActividad
                    .Any(laActividad => laActividad.NombreActividadFinanciera == modeloDeActividad.NombreActividadFinanciera);

                if (!actividadDuplicada)
                {
                 
                    int cantidadDeDatosGuardados = await _registarActividades.Guardar(modeloDeActividad);

                   
                    await _registrarBitacora.Registrar(new BitacoraEventosDto
                    {
                        TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        TipoDeEvento = "Registrar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = "Se registro una nueva actividad financiera",
                        DatosAnteriores = "Vacio",
                        DatosPosteriores = $"Nombre: {modeloDeActividad.NombreActividadFinanciera}",
                        StackTrace = ""
                    });
                    TempData["Alerta"] = "La actividad se registro correctamente.";
                    TempData.Keep("Alerta");
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Alerta"] = "Error al reactivar la actividad. Intente nuevamente.";
                    TempData.Keep("Alerta");
                    ModelState.AddModelError("NombreActividadFinanciera", "Ya existe una actividad con este nombre.");
               
                    return View(modeloDeActividad);
                }

            }
            catch (Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Error al registrar una nueva actividad financiera",
                    DatosAnteriores = "", 
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace 
                });

                return View(modeloDeActividad);
            }
        }


        [Authorize(Roles = "Administrador")]
        // GET: ActividadFinanciera/Edit/5
        public ActionResult Edit(int id)
        {
            ActividadFinancieraDto laActividad = _obtenerPorId.Obtener(id);
            return View(laActividad);
        }

        [Authorize(Roles = "Administrador")]
        // POST: ActividadFinanciera/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ActividadFinancieraDto laActividad)
        {
            try
            {
                var existeActividad = _listarActividadFinanciera.Listar();
                bool actividadDuplicada = existeActividad
                    .Any(laActividadValidada => laActividadValidada.NombreActividadFinanciera == laActividad.NombreActividadFinanciera && laActividadValidada.IdActividadFinanciera != laActividad.IdActividadFinanciera);

                if (actividadDuplicada)
                {
                    ModelState.AddModelError("NombreActividadFinanciera", "Ya existe una actividad con este nombre.");
                    return View(laActividad);
                }
                else
                {
                   
                    var actividadAnterior = _listarActividadFinanciera.Listar().FirstOrDefault(a => a.IdActividadFinanciera == laActividad.IdActividadFinanciera);

                    if (actividadAnterior != null)
                    {
                       
                      
                        await _registrarBitacora.Registrar(new BitacoraEventosDto
                        {
                            TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                            TipoDeEvento = "Editar",
                            FechaDeEvento = DateTime.Now,
                            DescripcionDeEvento = $"Se actualizó la actividad financiera para la persona",
                            DatosAnteriores = $"Nombre: {actividadAnterior.NombreActividadFinanciera}\n" +
                            $"Descripción: {actividadAnterior.DescripcionActividadFinanciera}\n" +
                            $"Estado: {actividadAnterior.Estado}",
                            DatosPosteriores = $"Nombre: {laActividad.NombreActividadFinanciera}\n" +
                            $"Descripción: {laActividad.DescripcionActividadFinanciera}\n" +
                            $"Estado: {laActividad.Estado}",
                            StackTrace = "" 
                        });
                    }

                  
                    int cantidadDeDatosActualizados = await _editarActividadN.Actualizar(laActividad);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
               
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Error al editar la actividad financiera",
                    DatosAnteriores = "", 
                    DatosPosteriores = "", 
                    StackTrace = ex.StackTrace
                });

                
                ViewBag.cantidadDeDatosActualizados = 0;
                ViewBag.mensaje = "Ocurrió un error inesperado, por favor intente nuevamente.";
                return View(laActividad);
            }
        }

        [Authorize(Roles = "Administrador")]
        // GET: ActividadFinanciera/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: ActividadFinanciera/Delete/5
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
                        TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        TipoDeEvento = "Activar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = $"Se reactivó la actividad financiera para la persona",
                        DatosAnteriores = $"Estado: Inactivo",
                        DatosPosteriores = $"Estado: Activo",
                        StackTrace = "" 
                    });

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo activar la actividad financiera.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error al activar la actividad financiera",
                    DatosAnteriores = $"",
                    DatosPosteriores = $"",
                    StackTrace = ex.StackTrace
                });
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return RedirectToAction("Index");
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
                        TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                        TipoDeEvento = "Inactivar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = $"Se inactivo la actividad financiera para la persona",
                        DatosAnteriores = $"Estado: Activo",
                        DatosPosteriores = $"Estado: Inactivo",
                        StackTrace = ""
                    });
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo inactivar la actividad financiera.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_FINANCIERA",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error al inactivar la actividad financiera",
                    DatosAnteriores = $"",
                    DatosPosteriores = $"",
                    StackTrace = ex.StackTrace
                });
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return RedirectToAction("Index");
            }
        }
    }
}
