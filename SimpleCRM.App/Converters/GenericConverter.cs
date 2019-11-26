using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimpleCRM.App.Converters
{
    public abstract class GenericConverter<T, TDto>
    {
        public abstract TDto ToDto(T item);


        public ICollection<TDto> ToDtoList(IEnumerable<T> objectList)
        {
            Collection<TDto> objectDtoList = new Collection<TDto>();

            foreach (var item in objectList)
            {
                objectDtoList.Add(ToDto(item));
            }

            return objectDtoList;
        }



    }
}
