using SiFac.DAL.Entidades;

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    
    // Propiedades de navegación
    public virtual ICollection<RolPermiso> RolesPermisos { get; set; }
    public virtual ICollection<Usuario> Usuarios { get; set; }
}