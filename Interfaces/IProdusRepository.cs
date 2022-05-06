using DAWW.Dto;
using DAWW.Models;

namespace DAWW.Interfaces
{
    public interface IProdusRepository
    {
        ICollection<Produs> GetProduse();
        Produs GetProdusById(int id);
        Produs GetProdusByName(string nume);
        bool ProdusExists(int id);
        bool CreateProdus(Produs produs);
        bool Save();

 
        
    }
}
