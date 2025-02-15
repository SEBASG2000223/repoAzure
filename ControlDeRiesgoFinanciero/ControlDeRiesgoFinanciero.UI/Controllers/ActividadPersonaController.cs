using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ListarActividadesNoRegistradas;
using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.ActividadPersona.ListarPersonas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Eliminar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.ListarActividadesNoRegistradas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.ListarPersonas;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.LN.ActividadFinanciera.Listar;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.Actualizar;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.Eliminar;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.Listar;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.ListarActividadesNoRegistradas;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.ListarPersonaPorId;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.ActividadPersona.Registrar;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.LN.Personas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class ActividadPersonaController : Controller
    {

        IRegistrarActividadPersonaLN _registrar;
        IEliminarActividadPersonaLN _eliminar;
        IListarActividadPersonaLN _listar;
        IObtenerActividadPersonaPorIdLN _obtenerPorId;
        IListarPersonasPorIdLN _obtenerPersonas;
        IListarActividadesNoRegistradasLN _listarNoRgistradas;
        IListarActividadFinancieraLN _listarActividadFinanciera;
        IObtenerPersonasPorIdLN _obtenerPersonaPorId;
        IActualizarActividadPersonaLN _actualizar;
        IRegistrarBitacoraEventosLN _registrarBitacora;
        public ActividadPersonaController()
        {
            _listarActividadFinanciera = new ListarActividadFinancieraLN();
            _registrar = new RegistrarActividadPersonaLN();
            _eliminar = new EliminarActividadPersonaLN();
            _listar = new ListarActividadPersonaLN();
            _obtenerPorId = new ObtenerActividadPersonaPorIdLN();
            _obtenerPersonas = new ListarPersonaPorIdLN();
            _listarNoRgistradas = new ListarActividadesNoRegistradasLN();
            _obtenerPersonaPorId = new ObtenerPersonasPorIdLN();
            _actualizar = new ActualizarActividadPersonaLN();
            _registrarBitacora = new RegistrarBitacoraEventosLN();
        }

        [Authorize(Roles = "Administrador, Analista")]

        // GET: ActividadPersona
        public ActionResult Index()
        {
            ViewBag.Title = "Actividades Personas";
            List<ActividadPersonaDto> laListaDeActividades = _listar.Listar();
            return View(laListaDeActividades);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: ActividadPersona/Detalles/5
        public async Task<ActionResult> Actividades(int idPersona)
        {
            try
            {
               
                ViewBag.IdPersona = idPersona;

                List<ActividadPersonaDto> actividades = _obtenerPersonas.ListarActividades(idPersona);
                return View(actividades);
            }
            catch
            {
                return View();
            }
        }




        [Authorize(Roles = "Administrador, Analista")]
        // GET: ActividadPersona/Create
        public ActionResult Create(int idPersona)
        {
           
            var modeloDeActividadPersona = new ActividadPersonaDto
            {
                IdPersona = idPersona
            };

            ViewBag.Title = "Actividades Personas";

           
            List<ActividadFinancieraDto> todasLasActividades = _listarActividadFinanciera.Listar()
                .Where(a => a.Estado)
                .ToList();

            List<ActividadPersonaDto> actividadesRegistradas = _listarNoRgistradas.ListarPersonasNoRegistradas(idPersona);

           
            var actividadesNoRegistradas = todasLasActividades
                .Where(actividad =>
                    !actividadesRegistradas.Any(registrada => registrada.IdActividadFinanciera == actividad.IdActividadFinanciera))
                .ToList();

       
            ViewBag.ActividadesDisponibles = actividadesNoRegistradas
                .Select(a => new SelectListItem
                {
                    Value = a.IdActividadFinanciera.ToString(),
                    Text = a.NombreActividadFinanciera 
                })
                .ToList();

            return View(modeloDeActividadPersona);
        }



        [Authorize(Roles = "Administrador, Analista")]
        [HttpPost]
        public async Task<ActionResult> Create(ActividadPersonaDto modelo)
        {
            try
            {
               
                var actividadExistente = _listar.Listar()
                    .FirstOrDefault(a =>
                        a.IdPersona == modelo.IdPersona &&
                        a.IdActividadFinanciera == modelo.IdActividadFinanciera);

                if (actividadExistente != null)
                {
                    if (!actividadExistente.Estado)
                    {
                    
                        actividadExistente.Estado = true;
                        int datosActualizados = await _actualizar.Actualizar(actividadExistente);

                        if (datosActualizados > 0)
                        {
                            var actividadFinanciera = _listarActividadFinanciera.Listar()
                                .FirstOrDefault(a => a.IdActividadFinanciera == modelo.IdActividadFinanciera);

                            string nombreActividad = actividadFinanciera?.NombreActividadFinanciera ?? "Desconocido";

                        
                            await _registrarBitacora.Registrar(new BitacoraEventosDto
                            {
                                TablaDeEvento = "ACTIVIDAD_PERSONA",
                                TipoDeEvento = "Reactivar",
                                FechaDeEvento = DateTime.Now,
                                DescripcionDeEvento = "Se reactivó la actividad financiera",
                                DatosAnteriores = "Estado: Inactivo",
                                DatosPosteriores = $"Estado: Activo, Nombre: {nombreActividad}",
                                StackTrace = ""
                            });

                            TempData["Alerta"] = "La actividad se activó correctamente.";
                            TempData.Keep("Alerta");
                            return RedirectToAction("Actividades", new { idPersona = modelo.IdPersona });
                        }
                        else
                        {
                            TempData["Alerta"] = "Error al reactivar la actividad. Intente nuevamente.";
                            TempData.Keep("Alerta");
                            return View(modelo);
                        }
                    }

                    TempData["Alerta"] = "La actividad ya está activa.";
                    TempData.Keep("Alerta");
                    return RedirectToAction("Actividades", new { idPersona = modelo.IdPersona });
                }

             
                modelo.Estado = true;
                int datosGuardados = await _registrar.Registrar(modelo);

                if (datosGuardados > 0)
                {
                    var actividadFinanciera = _listarActividadFinanciera.Listar()
                        .FirstOrDefault(a => a.IdActividadFinanciera == modelo.IdActividadFinanciera);

                    string nombreActividad = actividadFinanciera?.NombreActividadFinanciera ?? "Desconocido";

             
                    await _registrarBitacora.Registrar(new BitacoraEventosDto
                    {
                        TablaDeEvento = "ACTIVIDAD_PERSONA",
                        TipoDeEvento = "Registrar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = "Se registró una nueva actividad financiera",
                        DatosAnteriores = "Vacío",
                        DatosPosteriores = $"Nombre de la actividad financiera creada: {nombreActividad}",
                        StackTrace = ""
                    });

                    TempData["Alerta"] = "La actividad se registró correctamente.";
                    TempData.Keep("Alerta");
                    return RedirectToAction("Actividades", new { idPersona = modelo.IdPersona });
                }
                else
                {
                    TempData["Alerta"] = "Error al registrar la actividad.";
                    TempData.Keep("Alerta");
                    return View(modelo);
                }
            }
            catch (Exception ex)
            {
                // Registrar error en bitácora
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_PERSONA",
                    TipoDeEvento = "ERROR",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error inesperado al registrar actividad financiera para la persona con ID: {modelo.IdPersona}. Excepción: {ex.Message}",
                    DatosAnteriores = "",
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace
                });

                TempData["Alerta"] = $"Ocurrió un error inesperado: {ex.Message}";
                TempData.Keep("Alerta");
                return View(modelo);
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: ActividadPersona/Edit/5
        public ActionResult Edit(int id)
        {
            ActividadPersonaDto lasActividades = _obtenerPorId.Obtener(id);
            return View(lasActividades);
        }

        // POST: ActividadPersona/Edit/5
        [Authorize(Roles = "Administrador, Analista")]
        [HttpPost]
        public async Task<ActionResult> Edit(ActividadPersonaDto lasActividades)
        {
            try
            {
                int cantidadDeDatosActualizados = await _actualizar.Actualizar(lasActividades);

                if (cantidadDeDatosActualizados == 0)
                {
                    ViewBag.cantidadDeDatosActualizados = cantidadDeDatosActualizados;
                    ViewBag.mensaje = "Ocurrió un error inesperado, favor intente nuevamente.";
                    return View(lasActividades);
                }

                
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_PERSONA",
                    TipoDeEvento = "Eliminar",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Se ianctivo la actividad financiera",
                    DatosAnteriores = $"Estado: Activo", 
                    DatosPosteriores = "Estado: Inactivo",
                    StackTrace = ""
                });

                return RedirectToAction("Actividades", "ActividadPersona", new { idPersona = lasActividades.IdPersona });
            }
            catch(Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ACTIVIDAD_PERSONA",
                    TipoDeEvento = "ERROR",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error al ianctivar la actividad",
                    DatosAnteriores = "",
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace
                });
                ViewBag.cantidadDeDatosActualizados = 0;
                ViewBag.mensaje = "Ocurrió un error inesperado, favor intente nuevamente.";
                return View(lasActividades);
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: ActividadPersona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: ActividadPersona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
         

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
