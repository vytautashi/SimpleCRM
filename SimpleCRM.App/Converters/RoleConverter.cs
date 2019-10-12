using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public class RoleConverter : GenericConverter<Role, RoleDto>
    {
        public override RoleDto ToDto(Role role)
        {
            RoleDto roleDto = new RoleDto
            {
                RoleId = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
            return roleDto;
        }

        public RoleListViewModel ToRoleListViewModel(IEnumerable<Role> roles)
        {
            return new RoleListViewModel(ToDtoList(roles));
        }

    }
}
