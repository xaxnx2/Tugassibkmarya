using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class EducationRepository : IEducationRepository
    {

        private readonly MyContext _context;
        public EducationRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Education> GetAll()
        {
            return _context.Set<Education>().ToList();
        }

        public Education? GetById(int id)
        {
            return _context.Set<Education>().Find(id);
        }

        public int Insert(Education Education)
        {
            _context.Set<Education>().Add(Education);
            return _context.SaveChanges();
        }

        public int Update(Education Education)
        {
            _context.Set<Education>().Update(Education);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Education = GetById(id);
            if (Education == null)
                return 0;

            _context.Set<Education>().Remove(Education);
            return _context.SaveChanges();
        }

    }
}
