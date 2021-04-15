using System;
using System.Collections.Generic;
using System.Linq;
using SISCO.CapaDatos.DBModels;
using SISCO.CapaDatos.ViewModels;
using System.Data.Entity;

namespace SISCO.CapaLogica
{
    public class ProveedorBLL
    {

        public static void Add(ProveedorViewModel modelo)
        {
            using(var context = new SISCOContext())
            {
                var proveedor = new Proveedor
                {
                    Id = Guid.NewGuid(),
                    Nombre = modelo.Nombre,
                    Direccion = modelo.Direccion,
                    Correo = modelo.Correo,
                    Telefono = modelo.Telefono,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };
                context.Proveedor.Add(proveedor);
                context.SaveChanges();
            }
        }

        public static ProveedorViewModel Fetch(Guid id)
        {
            ProveedorViewModel result = null;

            using (var context = new SISCOContext())
            {
                var proveedor = context.Proveedor.FirstOrDefault(x => x.Id.Equals(id));

                if(proveedor != null)
                {
                    result = new ProveedorViewModel(proveedor);
                }
            }

            return result;
        }

        public static IEnumerable<ProveedorViewModel> Fetch()
        {
            using (var context = new SISCOContext())
            {
                return context.Proveedor.Where(x => x.Activo).ToList().Select(x => new ProveedorViewModel(x));
            }
        }

        public static IEnumerable<ProveedorViewModel> FetchAll()
        {
            using (var context = new SISCOContext())
            {
                return context.Proveedor.ToList().Select(x => new ProveedorViewModel(x));
            }
        }

        public static void Update(ProveedorViewModel modelo)
        {
            using(var context = new SISCOContext())
            {
                var proveedor = context.Proveedor.Find(modelo.Id);

                proveedor.Nombre = modelo.Nombre;
                proveedor.Direccion = modelo.Direccion;
                proveedor.Correo = modelo.Correo;
                proveedor.Telefono = modelo.Telefono;
                proveedor.Activo = modelo.Activo.Equals("Sí");

                context.SaveChanges();
            }
        }
    }
}
