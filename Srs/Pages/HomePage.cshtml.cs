using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Srs.Models;

namespace Srs.Pages;

public class HomePage : PageModel
{
    private readonly ApplicationDbContext _context;

        public HomePage(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Good> Goods { get; set; }
        public IList<Order> Orders { get; set; }

        // Метод для загрузки товаров и заказов пользователя
        public async Task OnGetAsync()
        {
            Goods = await _context.Goods.ToListAsync();

            // Получаем UserId из сессии
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                // Извлекаем заказы для этого пользователя
                Orders = await _context.Orders
                    .Where(o => o.UserId == userId.Value)
                    .Include(o => o.Good) // Включаем информацию о товаре
                    .ToListAsync();
            }
        }

        // Метод для создания заказа
        public async Task<IActionResult> OnPostCreateOrderAsync(int goodsId, int quantity)
        {
            // Получаем UserId из сессии
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                // Проверяем, существует ли товар и есть ли он в наличии
                var goods = await _context.Goods.FindAsync(goodsId);
                if (goods != null && goods.InStock && quantity > 0)
                {
                    // Создаем заказ
                    var order = new Order
                    {
                        UserId = userId.Value,  // Используем UserId как int
                        GoodId = goods.Id,
                        Count = quantity
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Заказ успешно добавлен!";
                    return RedirectToPage();
                }

                // Если товар не найден или его нет в наличии (для отладки)
                TempData["Error"] = "Ошибка при создании заказа.";
                return RedirectToPage();
            }

            // Если UserId не найден в сессии (для отладки)
            TempData["Error"] = "Пользователь не найден.";
            return RedirectToPage();
        }

}