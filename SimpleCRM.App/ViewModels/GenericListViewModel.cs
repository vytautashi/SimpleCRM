using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class GenericListViewModel<TDto>
    {
        public IEnumerable<TDto> ItemsDto { get; set; }

        public GenericListViewModel()
        {
        }
        public GenericListViewModel(IEnumerable<TDto> itemsDto)
        {
            this.ItemsDto = itemsDto;
        }
    }
}
