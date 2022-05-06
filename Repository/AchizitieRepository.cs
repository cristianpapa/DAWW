using DAWW.Data;
using DAWW.Interfaces;
using DAWW.Models;

namespace DAWW.Repository
{
    public class AchizitieRepository : IAchizitieRepository
    {
        private readonly DataContext _context;

        public AchizitieRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateAchizitie(Achizitie achizitie)
        {
            _context.Add(achizitie);
            return Save();
        }

        public ICollection<Achizitie> GetAchizitii()
        {
            return _context.Achizitii.OrderBy(x => x.IdUser).ToList();
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
