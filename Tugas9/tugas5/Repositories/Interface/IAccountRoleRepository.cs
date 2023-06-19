using API.Repositories;
using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountRoleRepository:IGenericRepo<Accountrole,int>
    {
        IEnumerable<string> GetRolesByEmail(string email);
    }
}
