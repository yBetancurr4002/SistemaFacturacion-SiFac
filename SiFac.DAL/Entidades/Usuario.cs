using System;

namespace SiFac.DAL.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        // Propiedad de navegación
        public virtual Persona Persona { get; set; }
    }
}
