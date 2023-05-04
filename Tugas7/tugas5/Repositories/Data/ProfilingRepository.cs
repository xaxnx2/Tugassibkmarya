using Tugas6.Context;
using Tugas6.Models;
using tugas6.Repositories.Interface;

namespace tugas6.Repositories.Data
{
    public class ProfilingRepository : GenericRepo<Profiling,string,MyContext>,IProfilingRepository
    {
        public ProfilingRepository(MyContext context) : base(context) { }
       

    }
}
