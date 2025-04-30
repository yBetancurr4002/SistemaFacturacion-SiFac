namespace SiFac.DAL.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string CodigoCliente { get; set; }
        public string Nit { get; set; }
        
        // Propiedad de navegación
        public virtual Persona Persona { get; set; }
    }
}
