using SISCO.CapaLogica;
using SISCO.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SISCO.Web.Controllers
{
    public class ProveedoresController : Controller
    { 
        public ActionResult MostrarProveedor()
        {
            //Guardo los datos del metodo listarproveedor() de la clase ProveedorNegocio de la capa negocio
            var Model = ProveedorNegocio.ListarProveedor();
            return View(Model);
        }
     
        public ActionResult RegistrarProveedor()
        {
            return View();
        }
        //registrar proveeedores
       [HttpPost]
        public ActionResult RegistrarProveedor(Proveedor model)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                model.Id = obj;
                try
                {
                    ProveedorNegocio.AgregarProveedor(model);
                    return RedirectToAction("MostrarProveedor");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrio un error al registrar");
                    return View(model);
                }
            }else
            {
                return View(model);
            }
           
            
        }
        //Visualizar proveedores
        public ActionResult GetProveedor(Guid Id)
        {
            var Proveedor = ProveedorNegocio.GetProveedor(Id);
            return View(Proveedor);
        }
        //Editar proveedores
        public ActionResult EditarProveedor(Guid Id)
        {
            var Proveedor = ProveedorNegocio.GetProveedor(Id);
            return View(Proveedor);
        }

       
        [HttpPost]
        public ActionResult EditarProveedor(Proveedor model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProveedorNegocio.EditarProveedor(model);
                    return RedirectToAction("MostrarProveedor");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrio un error al editar");
                    return View(model);
                }
            }
            
            else
            {
                return View(model);
            }
            //Editar proveedores
        }
        //Eliminar proveedores
        public ActionResult EliminarProveedor(Guid? Id)
        {
            if (Id == null)
            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var Proveedor = ProveedorNegocio.GetProveedor(Id.Value);
                return View(Proveedor);
            
         
        }
        [HttpPost]
        public ActionResult EliminarProveedor(Guid Id)
        {
            try
            {
                ProveedorNegocio.EliminarProveedor(Id);
                return RedirectToAction("MostrarProveedor");
            }
            catch (Exception ex )
            {
                ModelState.AddModelError("", "Ocurrio un error");
                return View();

            }
        }
        //Eliminar proveedores
    }
}