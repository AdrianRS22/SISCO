using System;
using System.ComponentModel.DataAnnotations;

namespace SISCO.CapaDatos.ViewModels
{
    public class ProductoViewModel : BaseViewModel
    {
        public ProductoViewModel()
        {

        }

        public Guid Id { get; set; }

        [Display(Name = "Proveedor")]
        public ProveedorViewModel Proveedor { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        public decimal Precio { get; set; }

        [Display(Name = "Estado")]
        public string Activo { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }


        public override bool IsValid()
        {
            bool resultado = true;

            if (resultado && Activo == null) return false;

            return resultado;
        }
    }
}
