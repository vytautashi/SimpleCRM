using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        private RoleDto ToRoleDto(Role role)
        {
            RoleDto employeeDto = new RoleDto
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Description = role.Description,
            };
            return employeeDto;
        }
        public async Task<RoleListViewModel> GetListAsync()
        {
            IEnumerable<Role> roles;
            Collection<RoleDto> rolesDto;

            rolesDto = new Collection<RoleDto>();
            roles = await _roleRepository.GetListAsync();

            foreach (var e in roles)
            {
                rolesDto.Add(ToRoleDto(e));
            }

            return new RoleListViewModel{Roles = rolesDto};
        }
    }
}
