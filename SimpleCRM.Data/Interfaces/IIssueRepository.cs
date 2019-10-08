using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IIssueRepository
    {
        Task<IEnumerable<Issue>> GetListAsync();
    }
}
