using DAWW.Models;

namespace DAWW.Interfaces
{
    public interface IAchizitieRepository
    {
        ICollection<Achizitie> GetAchizitii();

        bool CreateAchizitie(Achizitie achizitie);
        bool Save();
    }
}
