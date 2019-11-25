using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class GenericViewModel<TDto>
    {
        public TDto ItemDto { get; set; }

        public GenericViewModel()
        {
        }
        public GenericViewModel(TDto itemDto)
        {
            this.ItemDto = itemDto;
        }
    }
}
