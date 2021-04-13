using SISCO.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCO.CapaDatos
{
    public class ProveedorDatos
    {
        //Agrega proveedor a la base de datos
        public void AgregarProveedor(Proveedor model)
        {
            using (var db = new SISCOContext())
            {
                db.Proveedor.Add(model);
                db.SaveChanges();
            }
        }

        public List<Proveedor> ListarProveedor()
        {
            //Se crea la conexion a la base mediante el contexto
            using (var db = new SISCOContext())
            {
                //retorna los registros de la tabla como lista
                return db.Proveedor.ToList();   
            }

        }
        public Proveedor GetProveedor(Guid Id)
        {
            using (var db = new SISCOContext())
            {
                //Retorna el id del proveedor 
                return db.Proveedor.Where(p => p.Id == Id).FirstOrDefault();
            }
        }
        public void EditarProveedor(Proveedor model )
        {
            //Anade los cambios a la base de datos
            using (var db = new SISCOContext())
            {
                var p = db.Proveedor.Find(model.Id);
                p.Nombre = model.Nombre;
                p.Direccion = model.Direccion;
                p.Correo = model.Correo;
                p.Telefono = model.Telefono;
                p.Activo = model.Activo;
                p.FechaCreacion = model.FechaCreacion;
                db.SaveChanges();

            }
        }
        public void EliminarProveedor(Guid Id)
        {
            //Elimina el proveedor
            using (var db = new SISCOContext())
            {
                var p = db.Proveedor.Find(Id);
                db.Proveedor.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
