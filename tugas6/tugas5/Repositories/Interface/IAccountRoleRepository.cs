using Tugas4.Models;

namespace tugas5.Repositories.Interface
{
    public interface IAccountRoleRepository
    {
        IEnumerable<Accountrole> GetAll();
        Accountrole? GetById(int id);
        int Insert(Accountrole Accountrole);
        int Update(Accountrole Accountrole);
        int Delete(int id);
    }
}
