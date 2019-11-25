using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public abstract class GenericConverterNew<T, TDto>
    {
        public abstract TDto ToDto(T item);


        protected ICollection<TDto> ToDtoList(IEnumerable<T> objectList)
        {
            Collection<TDto> objectDtoList = new Collection<TDto>();

            foreach (var item in objectList)
            {
                objectDtoList.Add(ToDto(item));
            }

            return objectDtoList;
        }


        public GenericListViewModel<TDto> ToListViewModel(IEnumerable<T> items)
        {
            return new GenericListViewModel<TDto>(ToDtoList(items));
        }

        public GenericViewModel<TDto> ToViewModel(T item)
        {
            return new GenericViewModel<TDto>(ToDto(item));
        }



    }
}
