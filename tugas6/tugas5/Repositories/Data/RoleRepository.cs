using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class RoleRepository : IRoleRepository
    {

        private readonly MyContext _context;
        public RoleRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Set<Role>().ToList();
        }

        public Role? GetById(int id)
        {
            return _context.Set<Role>().Find(id);
        }

        public int Insert(Role Role)
        {
            _context.Set<Role>().Add(Role);
            return _context.SaveChanges();
        }

        public int Update(Role Role)
        {
            _context.Set<Role>().Update(Role);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Role = GetById(id);
            if (Role == null)
                return 0;

            _context.Set<Role>().Remove(Role);
            return _context.SaveChanges();
        }

    }
}
