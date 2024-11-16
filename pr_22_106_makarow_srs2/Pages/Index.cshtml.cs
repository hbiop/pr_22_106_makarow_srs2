using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pr_22_106_makarow_srs2.Models.Entities;

namespace pr_22_106_makarow_srs2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Srs2Context _context;

        [BindProperty]
        public string Login { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Srs2Context context)
        {
            _logger = logger;
            _context = context;
        }

        // Метод для обработки GET-запроса (отображение формы)
        public void OnGet()
        {
        }

        // Метод для обработки POST-запроса (проверка логина и пароля)
        public IActionResult OnPost()
        {
            // Ищем пользователя с таким логином и паролем в базе данных
            var user = _context.Authorizations
                .FirstOrDefault(u => u.Login == Login && u.Parol == Password);

            if (user != null)
            {
                // Если пользователь найден, перенаправляем на домашнюю страницу
                return RedirectToPage("/HomePage");
            }
            else
            {
                // Если пользователь не найден, добавляем ошибку в ModelState
                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль.");
                return Page(); // Возвращаем ту же страницу с ошибкой
            }
        }

    }
}
