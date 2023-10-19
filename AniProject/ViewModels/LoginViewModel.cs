using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace AniProject.ViewModels
{
    public class LoginViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="informe o usuário")]
        [Display(Name = "username")]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
