﻿using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class RoleListViewModel
    {
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}