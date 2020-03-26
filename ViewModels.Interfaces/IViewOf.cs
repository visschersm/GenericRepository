using AutoMapper;

namespace ViewModels.Interfaces
{
    public interface IViewOf<TEntity>
    {
        void Mapping(Profile profile)
        {
            var testtype = GetType();
            profile.CreateMap(typeof(TEntity), GetType());
        }
    }
}
