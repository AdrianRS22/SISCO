using SISCO.CapaDatos.DBModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace SISCO.CapaDatos.ViewModels
{
    public class ProveedorViewModel
    {
        public ProveedorViewModel()
        {

        }

        public ProveedorViewModel(Proveedor proveedor)
        {
            Id = proveedor.Id;
            Nombre = proveedor.Nombre;
            Direccion = proveedor.Direccion;
            Correo = proveedor.Correo;
            Telefono = proveedor.Telefono;
            Activo = proveedor.Activo ? "Activo" : "Inactivo";
            FechaCreacion = proveedor.FechaCreacion;
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        public string Telefono { get; set; }
        [Display(Name = "Estado")]
        public string Activo { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
    }
}
