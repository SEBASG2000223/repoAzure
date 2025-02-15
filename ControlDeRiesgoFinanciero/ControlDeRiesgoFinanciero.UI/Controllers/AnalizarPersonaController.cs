using ControlDeRiesgoFinanciero.Abstracciones.AccesoADatos.Interfaces.AnalizarPersona.ListarPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Analizar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.ListarPorId;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.AnalizarPersona.Registrar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadFinanciera;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.AnalizarPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ArchivoAnalisis;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.LN.AnalizarPersona.Analizar;
using ControlDeRiesgoFinanciero.LN.AnalizarPersona.Listar;
using ControlDeRiesgoFinanciero.LN.AnalizarPersona.ListarPorId;
using ControlDeRiesgoFinanciero.LN.AnalizarPersona.Registrar;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class AnalizarPersonaController : Controller
    {
         IAnalizarPersonaLN _analizarPersona; 
         IRegistrarAnalisisLN _registrarAnalisis;
        IRegistrarBitacoraEventosLN _registrarBitacora;
        IListarAnalisisPersonaLN _listarAnalisisPersona;
        IListarPorIdLN _listarPorIdM;

        public AnalizarPersonaController()
        {
            _analizarPersona = new AnalizarPersonaLN();
            _registrarAnalisis = new RegistrarAnalisisLN();
            _registrarBitacora = new RegistrarBitacoraEventosLN();
            _listarAnalisisPersona = new ListarAnalisisPersonaLN();
            _listarPorIdM = new ListarPorIdLN();
        }

        [Authorize(Roles = "Administrador, Analista")]

        public ActionResult ListarPorId(int idPersona)
        {
            try
            {

                List<AnalizarPersonaDto> laListaDeAnalisis = _listarPorIdM.ListarPorId(idPersona);
                return View("ListarPorId", laListaDeAnalisis);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AnalizarPersona", "ListarPorId"));
            }
        }


        [Authorize(Roles = "Administrador, Analista")]
        public async Task<ActionResult> Analizar(int idPersona)
        {
            try
            {
             
                 _analizarPersona.RealizarAnalisis(idPersona);
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ARCHIVO_ANALISIS",
                    TipoDeEvento = "Registrar analisis",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = "Se registro el analisis correctamente",
                    DatosAnteriores = $"Sin datos",
                    DatosPosteriores = $"Id de la persona registrada: {idPersona}",
                    StackTrace = string.Empty
                });
               
                _registrarAnalisis.RegistrarAnalisis(idPersona);

              return RedirectToAction("Listar", "AnalizarPersona");
            }
            catch (Exception ex)
            {
                await _registrarBitacora.Registrar(new BitacoraEventosDto
                {
                    TablaDeEvento = "ARCHIVO_ANALISIS",
                    TipoDeEvento = "ERROR",
                    FechaDeEvento = DateTime.Now,
                    DescripcionDeEvento = $"Error inesperado",
                    DatosAnteriores = "",
                    DatosPosteriores = "",
                    StackTrace = ex.StackTrace
                });
            
                return View("Error", new HandleErrorInfo(ex, "AnalizarPersona", "Analizar"));
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: AnalisisPersona
        public ActionResult Listar()
        {
            ViewBag.Title = "Los Análisis de Personas";
            List<ListarAnalisisPersonaDto> laListaDeAnalisis = _listarAnalisisPersona.Listar();
            return View(laListaDeAnalisis);
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: AnalizarPersona
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: AnalizarPersona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: AnalizarPersona/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: AnalizarPersona/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Analista")]
        // GET: AnalizarPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: AnalizarPersona/Edit/5
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
        // GET: AnalizarPersona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Analista")]
        // POST: AnalizarPersona/Delete/5
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
