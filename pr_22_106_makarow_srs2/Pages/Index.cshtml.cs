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

        // ����� ��� ��������� GET-������� (����������� �����)
        public void OnGet()
        {
        }

        // ����� ��� ��������� POST-������� (�������� ������ � ������)
        public IActionResult OnPost()
        {
            // ���� ������������ � ����� ������� � ������� � ���� ������
            var user = _context.Authorizations
                .FirstOrDefault(u => u.Login == Login && u.Parol == Password);

            if (user != null)
            {
                // ���� ������������ ������, �������������� �� �������� ��������
                return RedirectToPage("/HomePage");
            }
            else
            {
                // ���� ������������ �� ������, ��������� ������ � ModelState
                ModelState.AddModelError(string.Empty, "������������ ����� ��� ������.");
                return Page(); // ���������� �� �� �������� � �������
            }
        }

    }
}
