using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;
using tugas6.ViewModels;

namespace tugas6.Repositories.Data
{
    public class EmployeeRepository : GenericRepo<Employee,string,MyContext>,IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context) { }
        public string GetFullNameByEmail(string email)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email)!;
            return employee.FirstName + " " + employee.LastName;
        }


    }
}
