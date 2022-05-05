namespace DAWW.Models
{
    public class Livrare
    {
        public int Id { get; set; }
        public int IdAdresa { get; set; }
        public string FirmaCurierat { get; set; }
        public int Easybox { get; set; }
        public DateTime Data { get; set; }

        public virtual Adresa Adresa { get; set; }
        public virtual Comanda Comanda { get; set; }
    }
}
