using AniProject.Context;
using AniProject.Models;
using AniProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AniProject.Repository
{
    public class AnimesRepository : IAnimesRepository
    {
        private readonly DataContext _context;
        public AnimesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Anime> Animes => _context.Animes.Include(anime => anime.Category);

        public Anime GetAnimeById(int Id) => _context.Animes.FirstOrDefault(anime => anime.AnimeId == Id);
    }
}
