using Tugas4.Models;

namespace tugas5.Repositories.Interface
{
    public interface IProfilingRepository
    {
        IEnumerable<Profiling> GetAll();
        Profiling? GetById(string employee_nik);
        int Insert(Profiling Profiling);
        int Update(Profiling Profiling);
        int Delete(string employee_nik);
    }
}
