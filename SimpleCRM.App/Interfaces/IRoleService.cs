using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCRM.App.Dto;

namespace SimpleCRM.App.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetListAsync();
    }
}
