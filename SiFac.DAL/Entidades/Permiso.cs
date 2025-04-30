using System.Collections.Generic;

namespace SiFac.DAL.Entidades
{
    public class Permiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<RolPermiso> RolesPermisos { get; set; }
    } 
}