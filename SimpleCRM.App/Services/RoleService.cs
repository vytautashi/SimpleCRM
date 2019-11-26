using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.Converters;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private RoleConverter _roleConverter;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _roleConverter = new RoleConverter();
        }

        public async Task<IEnumerable<RoleDto>> GetListAsync()
        {
            IEnumerable<Role> roles = await _roleRepository.GetListAsync();

            return _roleConverter.ToDtoList(roles);
        }
    }
}
