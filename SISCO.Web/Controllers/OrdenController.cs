using System.Web.Mvc;
using SISCO.CapaLogica;
using System;
using System.Net;
using SISCO.CapaDatos.ViewModels;

namespace SISCO.Web.Controllers
{
    public class OrdenController : Controller
    {
        public ActionResult Lista()
        {
            var listaOrdenes = OrdenBLL.Fetch();
            return View(listaOrdenes);
        }

        public ActionResult Editar(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editarOrdenModelo = OrdenBLL.FetchEditOrdenModel(Id);

            if (editarOrdenModelo == null)
            {
                return HttpNotFound();
            }

            return View(editarOrdenModelo);
        }

        [HttpPost]
        public ActionResult Editar(Guid Id, EditarOrdenViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrdenBLL.Update(Id, modelo);
                    return RedirectToAction("Lista");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ha ocurrido un error al editar la orden");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Por favor verifica los campos");
            }

            return View(modelo);
        }

        public ActionResult Eliminar(Guid Id)
        {
            OrdenBLL.Eliminar(Id);
            return RedirectToAction("Lista");
        }
    }
}