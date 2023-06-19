using API.Repositories;
using API.ViewModels;
using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountRepository:IGenericRepo<Account,string>
    {

        int Register(RegisterVM registerVM);
        bool Login(LoginVM loginVM);
    }
}
