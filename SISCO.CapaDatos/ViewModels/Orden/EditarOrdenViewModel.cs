using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCO.CapaDatos.ViewModels
{
    public class EditarOrdenViewModel
    {
        [Required(ErrorMessage = "La provincia es requerida")]
        [MaxLength(50, ErrorMessage = "La provincia no puede tener más de {1} caracteres")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "El cantón es requerido")]
        [MaxLength(50, ErrorMessage = "El cantón no puede tener más de {1} caracteres")]
        public string Canton { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El estado del producto es requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "La cantidad comprada es requerida")]
        [Range(1, 50, ErrorMessage = "La cantidad comprada debe ser mayor a {1} y menor a {2}")]
        [Display(Name = "Cantidad Comprada")]
        public int Cantidad { get; set; }
    }
}
