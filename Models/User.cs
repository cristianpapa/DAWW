namespace DAWW.Models
{
    public class User
    {   
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Achizitie> Achizitii { get; set; }
    }
}
