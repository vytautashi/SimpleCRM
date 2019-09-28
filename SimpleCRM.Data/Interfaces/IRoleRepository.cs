using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetListAsync();
    }
}
