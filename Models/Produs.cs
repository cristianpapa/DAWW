namespace DAWW.Models
{
    public class Produs
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public string Producator { get; set; }
        public float Pret { get; set; }
        public float Reducere { get; set; }
        public string Marime { get; set; }

        public virtual ICollection<Achizitie> Achizitii { get; set; }

    }
}
