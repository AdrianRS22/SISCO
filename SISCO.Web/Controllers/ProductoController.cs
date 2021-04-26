using SISCO.CapaDatos.ViewModels;
using SISCO.CapaLogica;
using System;
using System.IO;
using System.Net;
using System.Web;
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


            if (modelo.IsValid())
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
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Por favor verifica que se ha seleccionado un estado o escogido una imagen");
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
            ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre", producto.Id);
            return View(producto);
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
                ModelState.AddModelError(string.Empty, "Por favor verifica que se ha seleccionado un estado o escogido una imagen");
            }

            var listaProveedor = ProveedorBLL.Fetch();
            ViewData["listaProveedor"] = new SelectList(listaProveedor, "Id", "Nombre", modelo.Id);

            return View(modelo);
        }
    }
}