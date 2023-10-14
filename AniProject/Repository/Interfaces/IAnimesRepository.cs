using AniProject.Context;
using AniProject.Models;

namespace AniProject.Repository.Interfaces
{
    public interface IAnimesRepository
    {
        public IEnumerable<Anime> Animes { get; }
        public Anime GetAnimeById(int Id);
    }
}
