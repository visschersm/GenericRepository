using AutoMapper;
using DataLayer.Entities;
using DataLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Implementation
{
    public class TodoService : GenericService<TodoItem>, ITodoService
    {
        public TodoService(ITodoContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
