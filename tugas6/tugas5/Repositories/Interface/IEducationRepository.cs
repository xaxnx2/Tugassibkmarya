using Tugas4.Models;

namespace tugas5.Repositories.Interface
{
    public interface IEducationRepository
    {
        IEnumerable<Education> GetAll();
        Education? GetById(int id);
        int Insert(Education Education);
        int Update(Education Education);
        int Delete(int id);
    }
}
