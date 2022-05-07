using AutoMapper;
using DAWW.Data;
using DAWW.Dto;
using DAWW.Interfaces;
using DAWW.Models;
using Microsoft.EntityFrameworkCore;

namespace DAWW.Repository
{
    public class AchizitieRepository : IAchizitieRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

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
            //return _mapper.Map<List<AchizitieDto2>>(_context.Achizitii.OrderBy(x => x.IdUser).Include(x => x.User).ToList());
            return _context.Achizitii.OrderBy(x => x.IdUser).Include(x => x.User).ToList();
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
