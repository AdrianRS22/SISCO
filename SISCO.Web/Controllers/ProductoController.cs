using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using SISCO.CapaDatos.ViewModels;
using SISCO.CapaLogica;


namespace SISCO.Web.Controllers
{
    public class ProductoController : Controller
    {

        public ActionResult Lista()
        {
            var listaProductos = ProductoBLL.FetchAll();
            return View(listaProductos);
        }

        public ActionResult Agregar()
        {
            var listaProveedor = ProveedorBLL.FetchAll();
            ViewBag.data = listaProveedor;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ProductoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductoBLL.Add(modelo);
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
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = ProductoBLL.Fetch(Id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            var listaProveedor = ProveedorBLL.FetchAll();
            ViewBag.data = listaProveedor;
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductoBLL.Update(modelo);
                    return RedirectToAction("Lista");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocurrio un error al editar");
                }
            }

            return View(modelo);
        }

        public ActionResult Eliminar(Guid Id)
        {
            ProductoBLL.Eliminar(Id);
            return RedirectToAction("Lista");
        }
       
    }
}