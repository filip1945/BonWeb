using BonWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonWeb.Controllers;

[Authorize(Roles = "Admin")]
public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var orders = _context.Orders
            .OrderByDescending(o => o.CreatedAt)
            .ToList();

        return View(orders);
    }

    public IActionResult Details(int id)
    {
        var order = _context.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }
    [HttpPost]
    public IActionResult MarkAsSent(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        order.Status = "Испратена";

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}