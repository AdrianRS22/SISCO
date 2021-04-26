using System;
using System.Net;
using System.Web.Mvc;
using SISCO.CapaDatos.ViewModels;
using SISCO.CapaLogica;

namespace SISCO.Web.Controllers
{
    public class ProveedorController : Controller
    {

        public ActionResult Lista()
        {
            if (User.IsInRole("Administrador"))
            {
                var listaProveedores = ProveedorBLL.FetchAll();
                return View(listaProveedores);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public ActionResult Agregar()
        {
            if (User.IsInRole("Administrador"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult Agregar(ProveedorViewModel modelo)
        {
            try
            {
                ProveedorBLL.Add(modelo);
                return RedirectToAction("Lista");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrio un error al agregar un proveedor");
            }

            return View();
        }

        public ActionResult Editar(Guid Id)
        {
            if (User.IsInRole("Administrador"))
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var proveedor = ProveedorBLL.Fetch(Id);

                if (proveedor == null)
                {
                    return HttpNotFound();
                }
                return View(proveedor);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(ProveedorViewModel modelo)
        {
            if (modelo.IsValid())
            {
                try
                {
                    ProveedorBLL.Update(modelo);
                    return RedirectToAction("Lista");
                }
                catch(Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrio un error al editar el proveedor");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Por favor selecciona el estado del proveedor");
            }

            return View(modelo);
        }
    }
}