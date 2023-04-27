using Tugas4.Models;

namespace tugas5.Repositories.Interface
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account? GetById(string employee_nik);
        int Insert(Account Account);
        int Update(Account Account);
        int Delete(string employee_nik);
    }
}
