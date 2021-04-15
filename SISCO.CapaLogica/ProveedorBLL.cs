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

        public void Add(ProveedorViewModel modelo)
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

        public ProveedorViewModel Fetch(Guid id)
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

        public List<ProveedorViewModel> Fetch()
        {
            List<ProveedorViewModel> result = new List<ProveedorViewModel>();

            using (var context = new SISCOContext())
            {
                var proveedorList = context.Proveedor.Where(x => x.Activo).AsEnumerable();

                if(proveedorList != null)
                {
                    result = proveedorList.Select(x => new ProveedorViewModel(x)).ToList();
                }
            }

            return result;
        }

        public void Update(ProveedorViewModel modelo)
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

        public void Delete(Guid id)
        {
            using(var context = new SISCOContext())
            {
                var proveedor = context.Proveedor.FirstOrDefault(x => x.Id.Equals(id));

                if(proveedor != null)
                {
                    proveedor.Activo = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
