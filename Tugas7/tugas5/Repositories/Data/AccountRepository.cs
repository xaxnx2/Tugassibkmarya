using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;
using tugas6.ViewModels;

namespace tugas6.Repositories.Data
{
    public class AccountRepository : GenericRepo<Account,string,MyContext>,IAccountRepository
    {
        public AccountRepository(MyContext context) : base(context) { }

        public int Register(RegisterVM registerVM)
        {
           
            int result = 0;

            //insert to university table
            var university = new University
            {
                name = registerVM.UniversityName,
            };
            _context.Set<University>().Add(university);
            result = _context.SaveChanges();
            //insert to education table
            var education = new Education
            {
                major = registerVM.Major,
                degree = registerVM.Degree,
                gpa = registerVM.Gpa,
                universityid = university.id
            };
            _context.Set<Education>().Add(education);
            result += _context.SaveChanges();

            //insert to employee table
            var employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Gender = registerVM.Gender,
                BirthDate = registerVM.BirthDate,
                Email = registerVM.Email,
                HiringDate = DateTime.Now,
                PhoneNumber = registerVM.PhoneNumber
            };
            _context.Set<Employee>().Add(employee);
            result += _context.SaveChanges();

            //insert to Account table
            var account = new Account
            {
                employee_nik = registerVM.NIK,
                password = registerVM.Password
            };
            _context.Set<Account>().Add(account);
            result += _context.SaveChanges();

            //insert to Profiling table
            var profiling = new Profiling
            {
                EmployeeNIK = registerVM.NIK,
                EducationId = education.id,
            };
            _context.Set<Profiling>().Add(profiling);
            result += _context.SaveChanges();

            //insert to AccountRole table
            var accountRole = new Accountrole
            {
                account_nik = registerVM.NIK,
                role_id = 1
            };
            _context.Set<Accountrole>().Add(accountRole);
            result += _context.SaveChanges();

            return result;

        }
        public bool Login(LoginVM loginVM)
        {
            // ambil data dari database berdasarkan email di tabel employee
            // gabungkan dari data tabel employee dengan tabel account berdasarkan NIK
            // cocokan data tersebut dengan password yang diinputkan
            // cek apakah data falid atau tidak
            var employeeemail = _context.Employees.FirstOrDefault(e => e.Email == loginVM.Email);
            var accountpass = _context.Account.FirstOrDefault(a => a.password == loginVM.Password);
  

            if (employeeemail != null) 
            { 
                if (accountpass != null)
                {
                    return true;
                }
            
            }
            return false;

        }

    }
}
