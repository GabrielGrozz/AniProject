using AniProject.Context;
using AniProject.Models;
using AniProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AniProject.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;

        public CategoriesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Caterories => _context.Categories;
    }
}
