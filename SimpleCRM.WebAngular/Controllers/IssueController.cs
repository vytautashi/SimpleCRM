﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.App.Dto;

namespace SimpleCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByEmployee(int id)
        {
            IssueListViewModel issueListViewModel = new IssueListViewModel();
            IssueDto[] issues =
            {
                new IssueDto
                {
                    Id = 1,
                    Name = "Deactivated advertisement id: 2",
                    Description = "",
                    Priority = 3,
                    IssueClosed = false,
                    IssueOpenDateTime = DateTime.Now,
                    IssueCloseDateTime = DateTime.Now,
                    CustomerId = 1,
                },
            };
            issueListViewModel.Issues = issues.ToList();
            return Ok(issueListViewModel);
        }

    }
}