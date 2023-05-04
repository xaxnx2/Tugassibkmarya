using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;

namespace tugas6.Repositories.Data
{
    public class EducationRepository : GenericRepo<Education,int,MyContext>,IEducationRepository
    {
        public EducationRepository(MyContext context) : base(context) { }
    }
}
