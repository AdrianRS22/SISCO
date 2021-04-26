using SISCO.CapaDatos.DBModels;
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
                    Imagen = modelo.Imagen,
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
                    result = new ProductoViewModel {
                        Id = producto.Id,
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Precio = producto.Precio,
                        Activo = producto.Activo ? "Activo" : "Inactivo",
                        Imagen = producto.Imagen,
                        FechaCreacion = producto.FechaCreacion
                    };

                    result.Proveedor = new ProveedorViewModel
                    {
                        Id = producto.Proveedor.Id,
                        Nombre = producto.Proveedor.Nombre,
                        Direccion = producto.Proveedor.Direccion,
                        Correo = producto.Proveedor.Correo,
                        Telefono = producto.Proveedor.Telefono,
                        Activo = producto.Proveedor.Activo ? "Activo" : "Inactivo",
                        FechaCreacion = producto.Proveedor.FechaCreacion
                    };
                }
            }

            return result;
        }

        public static List<ProductoViewModel> Fetch()
        {
            using (var context = new SISCOContext())
            {
                return context.Producto.Include("Proveedor").Where(x => x.Activo).Select(s => new ProductoViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Precio = s.Precio,
                    Activo = s.Activo ? "Activo" : "Inactivo",
                    Imagen = s.Imagen,
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
            }
        }

        public static decimal FetchPrecio(Guid productoId)
        {
            using(var context = new SISCOContext())
            {
                return context.Producto.FirstOrDefault(x => x.Id == productoId).Precio;
            }
        }

        public static List<ProductoViewModel> FetchAll()
        {
            using (var context = new SISCOContext())
            {
                return context.Producto.Include("Proveedor").Select(s => new ProductoViewModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Precio = s.Precio,
                    Activo = s.Activo ? "Activo" : "Inactivo",
                    Imagen = s.Imagen,
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
                producto.Imagen = modelo.Imagen;

                context.SaveChanges();
            }
        }

        public static void Comprar(ProductoCompraViewModel modelo, Guid productoId, string usuarioId)
        {
            using(var context = new SISCOContext())
            {
                var precioProducto = FetchPrecio(productoId);

                var orden = new Orden
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    Provincia = modelo.Provincia,
                    Canton = modelo.Canton,
                    Direccion = modelo.Direccion,
                    Costo = precioProducto,
                    Estado = "En progreso",
                    FechaCreacion = DateTime.Now
                };
                context.Orden.Add(orden);

                var ordenProducto = new OrdenXProducto
                {
                    Id = Guid.NewGuid(),
                    OrdenId = orden.Id,
                    ProductoId = productoId,
                    Cantidad = modelo.Cantidad
                };
                context.OrdenXProducto.Add(ordenProducto);

                context.SaveChanges();
            }
        }
    }
}
