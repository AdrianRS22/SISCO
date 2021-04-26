using System.ComponentModel.DataAnnotations;

namespace SISCO.CapaDatos.ViewModels
{
    public class ProductoCompraViewModel
    {
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, 50, ErrorMessage = "La cantidad debe ser mayor a {1} y menor a {2}")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "La provincia es requerida")]
        [MaxLength(50, ErrorMessage = "La provincia no puede tener más de {1} caracteres")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "El cantón es requerido")]
        [MaxLength(50, ErrorMessage = "El cantón no puede tener más de {1} caracteres")]
        [Display(Name = "Cantón")]
        public string Canton { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
    }
}
