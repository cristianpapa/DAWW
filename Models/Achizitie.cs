namespace DAWW.Models
{
    public class Achizitie
    {
        public int IdUser { get; set; }
        public int IdProdus { get; set; }
        public int IdComanda { get; set; }

        public virtual User User { get; set; }
        public virtual Produs Produs { get; set; }
        public virtual Comanda Comanda { get; set; }


    }
}
