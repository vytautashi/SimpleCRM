using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public static class RoleConverter
    {
        public static RoleDto ToRoleDto(Role role)
        {
            RoleDto roleDto = new RoleDto
            {
                RoleId = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
            return roleDto;
        }

        public static RoleListViewModel ToRoleListViewModel(IEnumerable<Role> roles)
        {
            Collection<RoleDto> rolesDto = new Collection<RoleDto>();

            foreach (var role in roles)
            {
                rolesDto.Add(ToRoleDto(role));
            }

            return new RoleListViewModel { Roles = rolesDto };
        }

    }
}
