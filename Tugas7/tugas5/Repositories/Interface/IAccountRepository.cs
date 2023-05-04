using tugas6.Repositories;
using tugas6.ViewModels;
using Tugas6.Models;

namespace tugas6.Repositories.Interface
{
    public interface IAccountRepository:IGenericRepo<Account,string>
    {
        int Register(RegisterVM registerVM);

    }
}
