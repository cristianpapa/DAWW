namespace DAWW.Models
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Strada { get; set; }
        public string Numar { get; set; }
        public string Bloc { get; set; }
        public string Scara { get; set; }
        public int Apartament { get; set; }
        public int CodPostal { get; set; }
        public string Oras { get; set; }
        public string Tara { get; set; }

        public virtual ICollection<Livrare> Livrari { get; set; }
    }
}
