namespace DAWW.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public int IdPlata { get; set; }
        public int IdLivrare { get; set; }
        public string Status { get; set; }
        public DateTime DataPlasare { get; set; }

        public virtual ICollection<Achizitie> Achizitii { get; set; }
        public virtual Plata Plata { get; set; }
        public virtual Livrare Livrare { get; set; }

    }
}
