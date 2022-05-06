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

        public ICollection<Achizitie> GetAchizitii()
        {
            return _context.Achizitii.OrderBy(x => x.IdUser).ToList();
        }
    }
}
