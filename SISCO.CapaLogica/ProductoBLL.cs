﻿using SISCO.CapaDatos.DBModels;
using SISCO.CapaDatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCO.CapaLogica
{
    public class ProductoBLL
    {
        public static void Add(ProductoViewModel modelo)
        {
            using (var context = new SISCOContext())
            {
                var producto = new Producto
                {
                    Id = Guid.NewGuid(),
                    Nombre = modelo.Nombre,
                    ProveedorId = modelo.Proveedor.Id,
                    Descripcion = modelo.Descripcion,
                    Precio = modelo.Precio,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }

        public static ProductoViewModel Fetch(Guid id)
        {
            ProductoViewModel result = null;

            using (var context = new SISCOContext())
            {
                var producto = context.Producto.Include("Proveedor").FirstOrDefault(x => x.Id.Equals(id));

                if (producto != null)
                {
                    /*
                    result = new ProductoViewModel(producto);
                    result.Proveedor = new ProveedorViewModel(producto.Proveedor);
                    */
                }
            }

            return result;
        }

        public static IEnumerable<ProductoViewModel> Fetch()
        {
            using (var context = new SISCOContext())
            {
                return context.Producto.Include("Proveedor").Where(x => x.Activo).ToList().Select(s => new ProductoViewModel
                {
                    Id = s.Id,
                    //Proveedor = new ProveedorViewModel(s.Proveedor),
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Precio = s.Precio,
                    Activo = s.Activo ? "Activo" : "Inactivo",
                    FechaCreacion = s.FechaCreacion
                });
            }
        }

        public static List<ProductoViewModel> FetchAll()
        {
            using (var context = new SISCOContext())
            {
                //var result = context.Producto.Include("Proveedor").ToList().Select(s => new ProductoViewModel
                //{
                //    Id = s.Id,
                //    Proveedor = new ProveedorViewModel(s.Proveedor),
                //    Nombre = s.Nombre,
                //    Descripcion = s.Descripcion,
                //    Precio = s.Precio,
                //    Activo = s.Activo ? "Activo" : "Inactivo",
                //    FechaCreacion = s.FechaCreacion
                //}).AsEnumerable();

                var result = context.Producto.Include("Proveedor").Select(s => new ProductoViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Precio = s.Precio,
                    Activo = s.Activo ? "Activo" : "Inactivo",
                    FechaCreacion = s.FechaCreacion,

                    Proveedor = new ProveedorViewModel
                    {
                        Id = s.Proveedor.Id,
                        Nombre = s.Proveedor.Nombre,
                        Direccion = s.Proveedor.Direccion,
                        Correo = s.Proveedor.Correo,
                        Telefono = s.Proveedor.Telefono,
                        Activo = s.Proveedor.Activo ? "Activo" : "Inactivo",
                        FechaCreacion = s.Proveedor.FechaCreacion
                    }
                }).ToList();
                return result;
            }
        }

        public static void Update(ProductoViewModel modelo)
        {
            using (var context = new SISCOContext())
            {
                var producto = context.Producto.Find(modelo.Id);

                producto.Nombre = modelo.Nombre;
                producto.ProveedorId = modelo.Proveedor.Id;
                producto.Descripcion = modelo.Descripcion;
                producto.Precio = modelo.Precio;
                producto.Activo = modelo.Activo.Equals("Activo");

                context.SaveChanges();
            }
        }

    }
}
