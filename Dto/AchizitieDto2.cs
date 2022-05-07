using DAWW.Models;

namespace DAWW.Dto
{
    public class AchizitieDto2
    {
        public int IdUser { get; set; }
        public int IdProdus { get; set; }
        public int IdComanda { get; set; }
        public virtual UserDto User { get; set; }
    }
}
