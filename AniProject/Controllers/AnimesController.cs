using AniProject.Context;
using AniProject.Models;
using AniProject.Repository;
using AniProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AniProject.Controllers
{
    public class AnimesController : Controller
    {
        //fazendo o acesso ao banco de dados atravez do repository
        private readonly IAnimesRepository _animeRepository;
        public AnimesController(IAnimesRepository repository)
        {
            _animeRepository = repository;
        }

        public IActionResult Index(DataContext data)
        {
            IEnumerable<Anime> animes = data.Animes;
            return View(animes);
        }
    }
}
