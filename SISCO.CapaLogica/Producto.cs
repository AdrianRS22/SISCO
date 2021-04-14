//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SISCO.CapaLogica
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.OrdenXProducto = new HashSet<OrdenXProducto>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProveedorId { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenXProducto> OrdenXProducto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}