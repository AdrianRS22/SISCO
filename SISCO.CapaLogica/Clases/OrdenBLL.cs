using System.Collections.Generic;
using System.Linq;
using SISCO.CapaDatos.ViewModels;
using SISCO.CapaDatos.DBModels;
using System;
using System.Data.Entity;

namespace SISCO.CapaLogica
{
    public class OrdenBLL
    {
        public static List<OrdenViewModel> Fetch()
        {
            using(var context = new SISCOContext())
            {
                return context.Orden.Select(s => new OrdenViewModel
                {
                    OrdenId = s.Id,
                    Provincia = s.Provincia,
                    Canton = s.Canton,
                    Direccion = s.Direccion,
                    Estado = s.Estado,
                    FechaCreacion = s.FechaCreacion
                }).ToList();
            }
        }

        public static List<OrdenViewModel> Fetch(string usuarioId)
        {
            using (var context = new SISCOContext())
            {
                return context.Orden
                    .Where(x => x.UsuarioId == usuarioId)
                    .Select(s => new OrdenViewModel
                    {
                        OrdenId = s.Id,
                        Provincia = s.Provincia,
                        Canton = s.Canton,
                        Direccion = s.Direccion,
                        Estado = s.Estado,
                        FechaCreacion = s.FechaCreacion
                    }).ToList();
            }
        }

        public static EditarOrdenViewModel FetchEditOrdenModel(Guid ordenId)
        {
            EditarOrdenViewModel resultado = null;

            using (var context = new SISCOContext())
            {
                var ordenXProducto = context.OrdenXProducto.Include("Orden").FirstOrDefault(x => x.OrdenId == ordenId);

                if(ordenXProducto != null)
                {
                    resultado = new EditarOrdenViewModel
                    {
                        Provincia = ordenXProducto.Orden.Provincia,
                        Canton = ordenXProducto.Orden.Canton,
                        Direccion = ordenXProducto.Orden.Direccion,
                        Estado = ordenXProducto.Orden.Estado,
                        Cantidad = ordenXProducto.Cantidad
                    };
                }
            }

            return resultado;
        }

        public static DetalleOrdenViewModel FetchOrdenDetail(Guid ordenId)
        {
            DetalleOrdenViewModel resultado = null;

            using(var context = new SISCOContext())
            {
                var ordenXProducto = context.OrdenXProducto
                    .Include("Orden")
                    .Include("Producto")
                    .FirstOrDefault(x => x.OrdenId == ordenId);

                if(ordenXProducto != null)
                {
                    resultado = new DetalleOrdenViewModel
                    {
                        NumeroOrden = ordenXProducto.OrdenId,
                        Provincia = ordenXProducto.Orden.Provincia,
                        Canton = ordenXProducto.Orden.Canton,
                        Direccion = ordenXProducto.Orden.Direccion,
                        Estado = ordenXProducto.Orden.Estado,
                        CodigoProducto = ordenXProducto.ProductoId,
                        NombreProducto = ordenXProducto.Producto.Nombre,
                        CostoProducto = ordenXProducto.Orden.Costo,
                        Cantidad = ordenXProducto.Cantidad,
                        CostoTotal = ordenXProducto.Orden.Costo * ordenXProducto.Cantidad
                    };
                }
            }

            return resultado;
        }

        public static void Update(Guid ordenId, EditarOrdenViewModel modelo)
        {
            using(var context = new SISCOContext())
            {
                var ordenXProducto = context.OrdenXProducto.Include("Orden").FirstOrDefault(x => x.OrdenId == ordenId);

                if(ordenXProducto != null)
                {
                    ordenXProducto.Orden.Provincia = modelo.Provincia;
                    ordenXProducto.Orden.Canton = modelo.Canton;
                    ordenXProducto.Orden.Direccion = modelo.Direccion;
                    ordenXProducto.Orden.Estado = modelo.Estado;
                    ordenXProducto.Cantidad = modelo.Cantidad;

                    context.SaveChanges();
                }
            }
        }

        public static void Eliminar(Guid ordenId)
        {
            using(var context = new SISCOContext())
            {
                var ordenXProducto = context.OrdenXProducto.FirstOrDefault(x => x.OrdenId == ordenId);

                if(ordenXProducto != null)
                {
                    var orden = context.Orden.FirstOrDefault(x => x.Id == ordenId);

                    context.Entry(ordenXProducto).State = EntityState.Deleted;
                    context.Entry(orden).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }
    }
}
