using SISCO.CapaDatos.ViewModels;
using SISCO.CapaLogica;
using System;
using System.Net;
using System.Web.Mvc;

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
            var listaProveedor = ProveedorBLL.Fetch();
            ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ProductoViewModel modelo)
        {

            try
            {
                ProductoBLL.Add(modelo);
                return RedirectToAction("Lista");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrio un error al agregar el producto");
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
            var listaProveedor = ProveedorBLL.Fetch();
            ViewBag.listaProveedor = new SelectList(listaProveedor, "Id", "Nombre");
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

    }
}