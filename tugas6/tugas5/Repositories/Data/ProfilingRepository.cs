using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class ProfilingRepository : IProfilingRepository
    {

        private readonly MyContext _context;
        public ProfilingRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Profiling> GetAll()
        {
            return _context.Set<Profiling>().ToList();
        }

        public Profiling? GetById(string employee_nik)
        {
            return _context.Set<Profiling>().Find(employee_nik);
        }

        public int Insert(Profiling Profiling)
        {
            _context.Set<Profiling>().Add(Profiling);
            return _context.SaveChanges();
        }

        public int Update(Profiling Profiling)
        {
            _context.Set<Profiling>().Update(Profiling);
            return _context.SaveChanges();
        }

        public int Delete(string employee_nik)
        {
            var Profiling = GetById(employee_nik);
            if (Profiling == null)
                return 0;

            _context.Set<Profiling>().Remove(Profiling);
            return _context.SaveChanges();
        }

    }
}
