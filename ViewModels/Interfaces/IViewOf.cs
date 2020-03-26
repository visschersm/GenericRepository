using AutoMapper;

namespace ViewModels.Interfaces
{
    public interface IViewOf<TEntity>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(TEntity), GetType());
            profile.CreateMap(typeof(TEntity), GetType()).ReverseMap();
        }
    }
}
