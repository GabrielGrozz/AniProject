using AniProject.Models;

namespace AniProject.Repository.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Caterories { get; }
    }
}
