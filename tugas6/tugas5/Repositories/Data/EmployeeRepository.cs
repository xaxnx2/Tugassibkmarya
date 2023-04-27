using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly MyContext _context;
        public EmployeeRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().ToList();
        }

        public Employee? GetById(string nik)
        {
            return _context.Set<Employee>().Find(nik);
        }

        public int Insert(Employee Employee)
        {
            _context.Set<Employee>().Add(Employee);
            return _context.SaveChanges();
        }

        public int Update(Employee Employee)
        {
            _context.Set<Employee>().Update(Employee);
            return _context.SaveChanges();
        }

        public int Delete(string nik)
        {
            var Employee = GetById(nik);
            if (Employee == null)
                return 0;

            _context.Set<Employee>().Remove(Employee);
            return _context.SaveChanges();
        }

    }
}
