using System;
using System.Collections.Generic;
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
            var listaProveedores = ProveedorBLL.FetchAll();
            return View(listaProveedores);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ProveedorViewModel modelo)
        {
            if (ModelState.IsValid)
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
            }

            return View();
        }

        public ActionResult Editar(Guid Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var proveedor = ProveedorBLL.Fetch(Id);

            if(proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Editar(ProveedorViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (modelo.IsValid())
                    {
                        ProveedorBLL.Update(modelo);
                        return RedirectToAction("Lista");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Por favor selecciona el estado del proveedor");
                    }
                }catch(Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrio un error al editar el proveedor");
                }
            }

            return View(modelo);
        }
    }
}