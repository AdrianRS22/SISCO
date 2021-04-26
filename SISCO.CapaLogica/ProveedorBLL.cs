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

                if (proveedor != null)
                {
                    result = new ProveedorViewModel
                    {
                        Id = proveedor.Id,
                        Nombre = proveedor.Nombre,
                        Direccion = proveedor.Direccion,
                        Correo = proveedor.Correo,
                        Telefono = proveedor.Telefono,
                        Activo = proveedor.Activo ? "Activo" : "Inactivo",
                        FechaCreacion = proveedor.FechaCreacion
                    };
                }
            }
            return result;
        }

        public static List<ProveedorViewModel> Fetch()
        {
            using (var context = new SISCOContext())
            {
                return context.Proveedor.Where(x => x.Activo).Select(s => new ProveedorViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion,
                    Correo = s.Correo,
                    Telefono = s.Telefono,
                    Activo = s.Activo ? "Activo" : "Inactivo",
                    FechaCreacion = s.FechaCreacion
                }).ToList();
            }
        }

        public static List<ProveedorViewModel> FetchAll()
        {
            using (var context = new SISCOContext())
            {
                return context.Proveedor.Select(s => new ProveedorViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion,
                    Correo = s.Correo,
                    Telefono = s.Telefono,
                    Activo = s.Activo ? "Activo" : "Inactivo",
                    FechaCreacion = s.FechaCreacion
                }).ToList();
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
                proveedor.Activo = modelo.Activo.Equals("Activo");

                context.SaveChanges();
            }
        }
    }
}
