using System;

namespace SiFac.DAL.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
