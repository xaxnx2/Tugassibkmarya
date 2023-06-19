using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data;
public class UniversityRepository : GenericRepo<University, int, MyContext>, IUniversityRepository
{
    public UniversityRepository(MyContext context) : base(context) { }
    public IEnumerable<University> GetByName(string name)
    {
        return _context.Universities.Where(x => x.name.Contains(name));
    }
}