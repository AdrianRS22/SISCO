using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SISCO.CapaDatos.DBModels;
using SISCO.CapaDatos.ViewModels;
using System.Data.Entity;



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
                    ProveedorId = modelo.ProveedorId,
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
                var producto = context.Producto.FirstOrDefault(x => x.Id.Equals(id));

                if (producto != null)
                {
                    result = new ProductoViewModel(producto);
                }
            }

            return result;
        }

        public static IEnumerable<ProductoViewModel> Fetch()
        {
            using (var context = new SISCOContext())
            {
                return context.Producto.Where(x => x.Activo).ToList().Select(x => new ProductoViewModel(x));
            }
        }

        public static IEnumerable<ProductoViewModel> FetchAll()
        {
            using (var context = new SISCOContext())
            {
                return context.Producto.ToList().Select(x => new ProductoViewModel(x));
            }
        }

        public static void Update(ProductoViewModel modelo)
        {
            using (var context = new SISCOContext())
            {
                var producto = context.Producto.Find(modelo.Id);

                producto.Nombre = modelo.Nombre;
                producto.ProveedorId = modelo.ProveedorId;
                producto.Descripcion = modelo.Descripcion;
                producto.Precio = modelo.Precio;
                producto.Activo = modelo.Activo.Equals("Activo");

                context.SaveChanges();
            }
        }
        
        public static void Eliminar(Guid id)
        {
            using (var context =  new SISCOContext())
            {
                var dato = context.Producto.Where(x => x.Id == id).FirstOrDefault();

                context.Producto.Remove(dato);
                context.SaveChanges();
            }
        }

        }
    }
    
        
    
 
    






 


    

