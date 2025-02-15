using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Detalles;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.ArchivoAnalisis.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.Detalles;
using ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.Listar;
using ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.ObtenerPorId;
using ControlDeRiesgoFinanciero.LN.ArchivoAnalisis.Registrar;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class ArchivoAnalisisController : Controller
    {
        IListarArchivoAnalisisLN _listarArchivoAnalisis;
        IDetallesArchivoAnalisisLN _detallesArchivoAnalisis;
        IRegistrarArchivoAnalisisLN _registrarArchivoAnalisisLN;
        IObtenerArchivoAnalisisPorIdLN _obtenerArchivoAnalisisPorIdLN;
        IRegistrarBitacoraEventosLN _registrarBitacora;

        public ArchivoAnalisisController()
        {
            _listarArchivoAnalisis = new ListarArchivoAnalisisLN();
            _detallesArchivoAnalisis = new DetallesArchivoAnalisisLN();
            _registrarArchivoAnalisisLN = new RegistrarArchivoAnalisisLN();
            _obtenerArchivoAnalisisPorIdLN = new ObtenerArchivoAnalisisPorIdLN();
            _registrarBitacora = new RegistrarBitacoraEventosLN();
        }

        [Authorize(Roles = "Administrador, Analista")]

        // GET: ArchivoAnalisis
        public ActionResult Listar()
        {
            ViewBag.Title = "Los Archivos de Análisis";
            List<ArchivoAnalisisDto> laListaDeArchivos = _listarArchivoAnalisis.Listar();
            return View(laListaDeArchivos);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: ArchivoAnalisis/Details/5
        public ActionResult Detalles(int id)
        {
            ViewBag.Title = "Detalles del Archivo";
            ArchivoAnalisisDto archivo = _obtenerArchivoAnalisisPorIdLN.Obtener(id);
            if (archivo == null)
            {
                return HttpNotFound();
            }
            return View(archivo);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: ArchivoAnalisis/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: ArchivoAnalisis/Create
        [HttpPost]
        public async Task<ActionResult> Create(ArchivoAnalisisDto modeloDelArchivo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _registrarArchivoAnalisisLN.Registrar(modeloDelArchivo);
              
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ARCHIVO_ANALISIS",
                    TipoDeEvento = "Registrar",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Se registro un nuevo archivo de analisis",
                    DatosAnteriores = "Vacio",
                    DatosPosteriores = $"Nombre: {modeloDelArchivo.Nombre}",
                    StackTrace = ""
                });
             
                TempData["Alerta"] = "El archivo de analisis se registro con exito.";
                TempData.Keep("Alerta"); // Mantener TempData para la próxima solicitud

                return RedirectToAction("Listar");
            }
            catch(Exception ex)
            {
             
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ARCHIVO_ANALISIS",
                    TipoDeEvento = "Error",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Error al registrar un nuevo archivo",
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
        // GET: ArchivoAnalisis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: ArchivoAnalisis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: ArchivoAnalisis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: ArchivoAnalisis/Delete/5
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
