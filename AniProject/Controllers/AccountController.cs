using AniProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace AniProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        [HttpGet]
        //passamos a nossa url de retorno
        public IActionResult Login(string returnUrl)
        {
            //retornamos a view instanciamos um novo view model com a string de retorno
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        //no nosso método post iremos fazer uma validação para verificarmos se os dados recebidos pelo formulário são validos
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            //usamos o ModelState.IsValid para verificarmos se os dados são válidos
            if (!ModelState.IsValid)
            {
                //caso seja inválido ele retorna a view com os erros
                return View(loginVm);
            }

            //vai procurar o usuario no banco
            var user = await _userManager.FindByNameAsync(loginVm.UserName);

            if (user != null)
            {
                //caso o usuario seja encontrado iremos tentar fazer o login
                //aqui na result usamos a instancia de SingInManager para fazermos isso, e passamos como argumento o usuario e a senha 
                //os false são para não persistirmos o login com cookies e o segundo para não bloquearmos a conta caso o login falhe
                var result = await _singInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                if (result.Succeeded)
                {
                   TempData["login"] = "login realizado com sucesso";
                    //caso o login ocorra com sucesso iremos redirecionar o usuario para a home caso ele não tenha uma url de retorno
                    if (String.IsNullOrEmpty(loginVm.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVm.ReturnUrl);
                }

            };

            //caso o usuario seja null iremos retornar um erro
            ModelState.AddModelError("", "Error to try login in");
            return View(loginVm);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            TempData["login"] = "Você realizou o Logout";
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public IActionResult Register()
        {
            //irá apenas retornar a view 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginVm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = loginVm.UserName };
                var result = await _userManager.CreateAsync(user, loginVm.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao tentar registrar usuário");
                }
            }
            return View(loginVm);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }














}
