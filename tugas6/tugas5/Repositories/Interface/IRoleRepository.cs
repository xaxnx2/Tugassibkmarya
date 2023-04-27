using Tugas4.Models;

namespace tugas5.Repositories.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role? GetById(int id);
        int Insert(Role Role);
        int Update(Role Role);
        int Delete(int id);
    }
}
