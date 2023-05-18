using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;

namespace tugas6.Repositories.Data
{
    public class RoleRepository : GenericRepo<Role,int,MyContext>,IRoleRepository
    {
        public RoleRepository(MyContext context) : base(context) { }

    }
}
