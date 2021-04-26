using System;

namespace SISCO.CapaDatos.ViewModels
{
    public class DetalleOrdenViewModel
    {
        public Guid NumeroOrden { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public Guid CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal CostoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
