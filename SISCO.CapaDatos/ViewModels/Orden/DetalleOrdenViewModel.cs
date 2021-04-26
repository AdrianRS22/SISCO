using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCO.CapaDatos.ViewModels
{
    public class DetalleOrdenViewModel
    {
        public Guid OrdenId { get; set; }
        public string Estado { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
    }
}
