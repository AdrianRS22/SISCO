using System;
using System.ComponentModel.DataAnnotations;

namespace SISCO.CapaDatos.ViewModels
{
    public class OrdenViewModel
    {
        [Display(Name = "# Orden")]
        public Guid OrdenId { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
