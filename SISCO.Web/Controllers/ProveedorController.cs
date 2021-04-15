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
                    ModelState.AddModelError("", "Ocurrio un error al registrar");
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
                    ProveedorBLL.Update(modelo);
                    return RedirectToAction("Lista");
                }catch(Exception)
                {
                    ModelState.AddModelError("", "Ocurrio un error al editar");
                }
            }

            return View(modelo);
        }
    }
}