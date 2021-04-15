using System.Web.Mvc;
using SISCO.CapaDatos.ViewModels;
using SISCO.CapaLogica;

namespace SISCO.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly ProveedorBLL proveedorLogica = new ProveedorBLL();

        public ActionResult List()
        {
            var listaProveedores = proveedorLogica.Fetch();
            return View(listaProveedores);
        }
    }
}