using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;
using tugas6.ViewModels;

namespace tugas6.Repositories.Data
{
    public class EmployeeRepository : GenericRepo<Employee,string,MyContext>,IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context) { }


    }
}
