using SISCO.CapaDatos.DBModels;
using System;

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
            Activo = proveedor.Activo;
            FechaCreacion = proveedor.FechaCreacion;
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
