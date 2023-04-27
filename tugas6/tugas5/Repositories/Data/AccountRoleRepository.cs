using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class AccountRoleRepository : IAccountRoleRepository
    {

        private readonly MyContext _context;
        public AccountRoleRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Accountrole> GetAll()
        {
            return _context.Set<Accountrole>().ToList();
        }

        public Accountrole? GetById(int id)
        {
            return _context.Set<Accountrole>().Find(id);
        }

        public int Insert(Accountrole Accountrole)
        {
            _context.Set<Accountrole>().Add(Accountrole);
            return _context.SaveChanges();
        }

        public int Update(Accountrole Accountrole)
        {
            _context.Set<Accountrole>().Update(Accountrole);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Accountrole = GetById(id);
            if (Accountrole == null)
                return 0;

            _context.Set<Accountrole>().Remove(Accountrole);
            return _context.SaveChanges();
        }

    }
}
