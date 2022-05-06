using DAWW.Data;
using DAWW.Dto;
using DAWW.Interfaces;
using DAWW.Models;

namespace DAWW.Repository
{
    public class ProdusRepository : IProdusRepository
    {
        private readonly DataContext _context;
        public ProdusRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateProdus(Produs produs)
        {
            _context.Add(produs);
            return Save();
        }

        public Produs GetProdusById(int id)
        {
            return _context.Produse.Where(x => x.Id == id).FirstOrDefault();
        
            //throw new NotImplementedException();
        }

        public Produs GetProdusByName(string nume)
        {
            return _context.Produse.Where(x => x.Denumire == nume).FirstOrDefault();
        }

        public ICollection<Produs> GetProduse()
        {
            return _context.Produse.OrderBy(p => p.Id).ToList();
        }

        public bool ProdusExists(int id)
        {
            var produs = _context.Produse.Where(x => x.Id == id);
            if (produs.Count() > 0)
                return true;
            return false; 
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            if (saved > 0)
                return true;
            return false;
        }
    }
}
