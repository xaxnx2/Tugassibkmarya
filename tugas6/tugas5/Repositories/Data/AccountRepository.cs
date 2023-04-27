using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class AccountRepository : IAccountRepository
    {

        private readonly MyContext _context;
        public AccountRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Set<Account>().ToList();
        }

        public Account? GetById(string employee_nik)
        {
            return _context.Set<Account>().Find(employee_nik);
        }

        public int Insert(Account Account)
        {
            _context.Set<Account>().Add(Account);
            return _context.SaveChanges();
        }

        public int Update(Account Account)
        {
            _context.Set<Account>().Update(Account);
            return _context.SaveChanges();
        }

        public int Delete(string employee_nik)
        {
            var Account = GetById(employee_nik);
            if (Account == null)
                return 0;

            _context.Set<Account>().Remove(Account);
            return _context.SaveChanges();
        }

    }
}
