using DataLayer.Entities;
using ViewModels.Interfaces;

namespace ViewModels.Todo
{
    public class Detailed : IViewOf<TodoItem>
    {
        public string Title { get; set; } = null!;

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<TodoItem, Detailed>();
        //}
    }
}
