using System;
using SISCO.CapaDatos.DBModels;
using System.ComponentModel.DataAnnotations;

namespace SISCO.CapaDatos.ViewModels
{
    public class ProductoViewModel
    {
        public ProductoViewModel()
        {

        }

        public ProductoViewModel(Producto producto)
        {
            Id = producto.Id;
            ProveedorId = producto.ProveedorId;
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
            Activo = producto.Activo ? "Activo" : "Inactivo";
            FechaCreacion = producto.FechaCreacion;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "El Proveedor es requerido")]
        [Display(Name = "Proveedor")]
        public Guid ProveedorId { get; set; }

        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        public decimal Precio { get; set; }

        [Display(Name = "Estado")]
        public string Activo { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
    }
}

