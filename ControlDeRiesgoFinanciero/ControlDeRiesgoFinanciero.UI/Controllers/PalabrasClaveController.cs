using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.PalabrasClave.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.PalabrasClave;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.Personas;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.LN.PalabrasClave.Editar;
using ControlDeRiesgoFinanciero.LN.PalabrasClave.Listar;
using ControlDeRiesgoFinanciero.LN.PalabrasClave.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.PalabrasClave.Registrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class PalabrasClaveController : Controller
    {
        IListarPalabraClaveLN _listarPalabraClave;
        IRegistrarPalabraClaveLN _registrarPalabraClave;
        IEditarPalabraClaveLN _editarPalabraClave;
        IObtenerPalabraClavePorIdLN _obtenerPalabraClave;
        IRegistrarBitacoraEventosLN _registrarBitacora;


        public PalabrasClaveController()
        {
            _listarPalabraClave = new ListarPalabraClaveLN();
            _registrarPalabraClave = new RegistrarPalabraClaveLN();
            _editarPalabraClave = new EditarPalabraClaveLN();
            _obtenerPalabraClave = new ObtenerPalabraClavePorIdLN();
            _registrarBitacora = new RegistrarBitacoraEventosLN();

        }

        [Authorize(Roles = "Administrador, Analista")]


        // GET: PalabrasClave
        public ActionResult ListarPalabraClave()
        {
            List<PalabrasClaveDto> laListaDePalabras = _listarPalabraClave.Listar();
            return View(laListaDePalabras);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: PalabrasClave/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: PalabrasClave/Create
        public ActionResult RegistrarPalabraClave()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: PalabrasClave/Create
        [HttpPost]
        public async Task<ActionResult> RegistrarPalabraClave(PalabrasClaveDto modeloDeLaPalabra)
        {
            try
            {
               
                var palabraExistente = _listarPalabraClave.Listar()
                    .FirstOrDefault(laPalabra => laPalabra.Palabra == modeloDeLaPalabra.Palabra);

                if (palabraExistente != null)
                {
                   
                    ViewBag.MensajeDeError = "La palabra ingresada ya está registrada.";
                    return View(modeloDeLaPalabra);
                }

               
                int cantidadDeDatosGuardados = await _registrarPalabraClave.Guardar(modeloDeLaPalabra);
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PALABRAS_CLAVE",
                    TipoDeEvento = "Registrar",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Se registro uan palabra clave",
                    DatosAnteriores = "Vacio",
                    DatosPosteriores = $"Palabra: {modeloDeLaPalabra.Palabra}",
                    StackTrace = ""
                });
              
                TempData["Alerta"] = "La palabra clave se registro con exito.";
                TempData.Keep("Alerta"); // Mantener TempData para la próxima solicitud

                return RedirectToAction("ListarPalabraClave");
            }
            catch(Exception ex)
            {
              
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PALABRAS_CLAVE",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Error al registrar la palabra clave",
                    DatosAnteriores = "",
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace
                });
            
                TempData["Alerta"] = $"Error al crear el registro: {ex.Message}";
                TempData.Keep("Alerta");
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: PalabrasClave/Edit/5
        public ActionResult EditarPalabraClave(int id)
        {
            PalabrasClaveDto laPalabra = _obtenerPalabraClave.Obtener(id);
            return View(laPalabra);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: PalabrasClave/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditarPalabraClave(PalabrasClaveDto laPalabra)
        {
            try
            {
                var existePalabra = _listarPalabraClave.Listar();
                bool palabraDuplicada = existePalabra
                    .Any(laPalabraValida => laPalabraValida.Palabra == laPalabra.Palabra && laPalabraValida.IdPalabra != laPalabra.IdPalabra);

                if (palabraDuplicada)
                {
                    ModelState.AddModelError("Palabra", "Ya existe esa palabra clave.");
                    return View(laPalabra);
                }
                else
                {
                    var palabraAnterior = _listarPalabraClave.Listar().FirstOrDefault(a => a.IdPalabra == laPalabra.IdPalabra);

                  
                    await _registrarBitacora.Registrar(new BitacoraEventosDto
                    {
                        TablaDeEvento = "PALABRAS_CLAVE",
                        TipoDeEvento = "Editar",
                        FechaDeEvento = DateTime.Now,
                        DescripcionDeEvento = $"Se actualizó correctamente",
                        DatosAnteriores = $"Palabra: {palabraAnterior.Palabra}\n" +
                        $"Orden: {palabraAnterior.Orden}",
                        DatosPosteriores = $"Palabra: {laPalabra.Palabra}\n" +
                        $"Orden: {laPalabra.Orden}",
                        StackTrace = "" 
                    });

                    int cantidadDeDatosActualizados = await _editarPalabraClave.Editar(laPalabra);

                    return RedirectToAction("ListarPalabraClave");
                }
            }
            catch(Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "PALABRAS_CLAVE",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Error al editar",
                    DatosAnteriores = "", 
                    DatosPosteriores = "", 
                    StackTrace = ex.StackTrace 
                });
                ViewBag.cantidadDeDatosActualizados = 0;
                ViewBag.mensaje = "Ocurrió un error inesperado, por favor intente nuevamente.";
                return View(laPalabra);
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: PalabrasClave/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: PalabrasClave/Delete/5
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
    }
}
