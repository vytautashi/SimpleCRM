﻿using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class IssueListViewModel
    {
        public IEnumerable<IssueDto> Issues { get; set; }
        public IssueListViewModel()
        {
        }

        public IssueListViewModel(IEnumerable<IssueDto> issuesDto)
        {
            this.Issues = issuesDto;
        }
    }
}