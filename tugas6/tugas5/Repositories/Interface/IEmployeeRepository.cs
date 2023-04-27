using Tugas4.Models;

namespace tugas5.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(string nik);
        int Insert(Employee Employee);
        int Update(Employee Employee);
        int Delete(string nik);
    }
}
