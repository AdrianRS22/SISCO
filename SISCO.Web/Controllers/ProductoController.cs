using Microsoft.AspNet.Identity.Owin;
using SISCO.CapaDatos.ViewModels;
using SISCO.CapaLogica;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace SISCO.Web.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Lista()
        {
            if (User.IsInRole("Administrador"))
            {
                var listaProductos = ProductoBLL.FetchAll();
                return View(listaProductos);
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
                var listaProveedor = ProveedorBLL.Fetch();
                ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult Agregar(ProductoViewModel modelo, HttpPostedFileBase imagenProducto)
        {

            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
                byte[] imagenData = null;
                using (var binaryReader = new BinaryReader(imagenProducto.InputStream))
                {
                    imagenData = binaryReader.ReadBytes(imagenProducto.ContentLength);
                }
                modelo.Imagen = imagenData;
            }

            try
            {
                ProductoBLL.Add(modelo);
                return RedirectToAction("Lista");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrio un error al agregar el producto");
            }

            var listaProveedor = ProveedorBLL.Fetch();
            ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre", modelo.Id);

            return View(modelo);
        }

        public ActionResult Detalle(Guid Id)
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

            return View(producto);

        }

        public ActionResult Editar(Guid Id)
        {
            if (User.IsInRole("Administrador"))
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
                ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre", producto.Id);
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel modelo, HttpPostedFileBase imagenProducto)
        {
            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
                byte[] imagenData = null;
                using (var binaryReader = new BinaryReader(imagenProducto.InputStream))
                {
                    imagenData = binaryReader.ReadBytes(imagenProducto.ContentLength);
                }
                modelo.Imagen = imagenData;
            }

            if (modelo.IsValid())
            {
                try
                {
                    ProductoBLL.Update(modelo);
                    return RedirectToAction("Lista");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ha ocurrido un error al editar el producto");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Por favor verifica que se ha seleccionado un estado");
            }

            var listaProveedor = ProveedorBLL.Fetch();
            ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre", modelo.Id);

            return View(modelo);
        }

        public ActionResult Comprar(EstadoCompra? estado, Guid Id)
        {
            ViewBag.EstadoCompra = estado == EstadoCompra.COMPRADO ? "La compra se ha realizado correctamente" : "";

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Comprar(Guid Id, ProductoCompraViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioId = User.Identity.GetUserId();
                    ProductoBLL.Comprar(modelo, productoId: Id, usuarioId: usuarioId);
                    return RedirectToAction("Comprar", new { Estado = EstadoCompra.COMPRADO });
                }
                catch(Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ha ocurrido un error a la hora de comprar el producto");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Por favor verifica los campos para la compra del producto");
            }
            return View();
        }

        public enum EstadoCompra
        {
            COMPRADO,
            ERROR
        }
    }
}