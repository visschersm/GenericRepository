using DataLayer.Entities;
using ViewModels.Interfaces;

namespace ViewModels.Todo
{
    public class Create : ICreate<TodoItem>
    {
        public string Title { get; set; } = null!;


    }
}
