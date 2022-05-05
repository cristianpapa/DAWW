namespace DAWW.Models
{
    public class User
    {   
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string email { get; set; }

        public virtual ICollection<Achizitie> Achizitii { get; set; }
    }
}
