using API.ViewModels;
using API.Models;

namespace API.Repositories.Interface
{
    public interface IEmployeeRepository:IGenericRepo<Employee,string>
    {
        string GetFullNameByEmail(string email);
    }
}
