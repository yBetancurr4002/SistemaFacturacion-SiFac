using SiFac.DAL.Entidades;

public class RolPermiso
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        
        // Propiedades de navegación
        public virtual Rol Rol { get; set; }
        public virtual Permiso Permiso { get; set; }
    }