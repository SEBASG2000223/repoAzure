using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.Listar;
using ControlDeRiesgoFinanciero.Abstracciones.LN.Interfaces.BitacoraEventos.ObtenerPorId;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.ActividadPersona;
using ControlDeRiesgoFinanciero.Abstracciones.Modelos.BitacoraEventos;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Editar;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.Listar;
using ControlDeRiesgoFinanciero.LN.BitacoraEventos.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControlDeRiesgoFinanciero.UI.Controllers
{
    public class BitacoraEventosController : Controller
    {

        IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
        IListarBitacoraEventosLN _ListarBitacoraEventosLN;
        IObtenerBitacoraEventosLN _IObtenerBitacoraEventosLN; 
        public BitacoraEventosController()
        {
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _ListarBitacoraEventosLN = new ListarBitacoraEventosLN();
            _IObtenerBitacoraEventosLN = new ObtenerBitacoraEventosLN();
        }

        [Authorize(Roles = "Administrador")]
        // GET: BitacoraEventos
        public ActionResult Index()
        {
            ViewBag.Title = "Bitacora de Eventos";
            List<BitacoraEventosDto> laListaDeBitacora = _ListarBitacoraEventosLN.Listar();
            return View(laListaDeBitacora);
        }

        [Authorize(Roles = "Administrador")]
        // GET: BitacoraEventos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // GET: BitacoraEventos/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: BitacoraEventos/Create
        [HttpPost]
        public async Task<ActionResult> Create(BitacoraEventosDto modelo)
        {
            try
            {
            
                // TODO: Add insert logic here
                int cantidadDeDatosGuardados = await _registrarBitacoraEventosLN.Registrar(modelo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrador")]
        // GET: BitacoraEventos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: BitacoraEventos/Edit/5
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

        [Authorize(Roles = "Administrador")]
        // GET: BitacoraEventos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: BitacoraEventos/Delete/5
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
