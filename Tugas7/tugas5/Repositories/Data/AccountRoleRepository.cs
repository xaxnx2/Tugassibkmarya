using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;

namespace tugas6.Repositories.Data
{
    public class AccountRoleRepository : GenericRepo<Accountrole,int,MyContext>,IAccountRoleRepository
    {
        public AccountRoleRepository(MyContext context) : base(context) { }

    }
}
