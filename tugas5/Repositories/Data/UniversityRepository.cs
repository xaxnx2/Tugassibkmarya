using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;

namespace tugas6.Repositories.Data
{
    public class UniversityRepository : GenericRepo<University, int, MyContext>, IUniversityRepository
    {
        public UniversityRepository(MyContext context) : base(context) { }


    }    
}
