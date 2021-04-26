using System;
using System.ComponentModel.DataAnnotations;

namespace SISCO.CapaDatos.ViewModels
{
    public class ProveedorViewModel : BaseViewModel
    {
        public ProveedorViewModel()
        {

        }

        [Required(ErrorMessage = "El proveedor es requerido")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre del Proveedor")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [MaxLength(100, ErrorMessage = "El correo no puede tener más de {1} caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        [MaxLength(10, ErrorMessage = "El teléfono no puede tener más de {1} digitos")]
        public string Telefono { get; set; }
        [Display(Name = "Estado")]
        public string Activo { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }


        public override bool IsValid()
        {
            var resultado = true;

            if (resultado && Activo == null) resultado = false;

            return resultado;
        }

    }
}
