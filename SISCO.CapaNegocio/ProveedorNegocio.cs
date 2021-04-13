using SISCO.CapaLogica;
using SISCO.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCO.CapaNegocio
{
    public class ProveedorNegocio
    {
        private static ProveedorDatos obj = new ProveedorDatos();

        public static void AgregarProveedor(Proveedor model)
        {
            //Retorna modelo vacio de proveedores
            obj.AgregarProveedor(model);
        }

        public static List<Proveedor> ListarProveedor()
        {
            //Retorna la lista de proveedores
            return obj.ListarProveedor();
        }
        public static Proveedor GetProveedor(Guid Id)
        {
            //Retorna id de proveedores
            return obj.GetProveedor(Id);
        }

        public static void EditarProveedor(Proveedor model)
        {
            //Retorna mddel de proveedores
            obj.EditarProveedor(model);
        }
        public static void EliminarProveedor(Guid Id)
        {
            //Retorna id de proveedores
            obj.EliminarProveedor(Id);
        }




        }
}
