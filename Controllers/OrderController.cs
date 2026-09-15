using System.Text.Json;
using BonWeb.Data;
using BonWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BonWeb.Controllers;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Checkout()
    {
        var cartJson = HttpContext.Session.GetString("Cart");

        if (string.IsNullOrEmpty(cartJson))
        {
            return RedirectToAction("Index", "Cart");
        }

        var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

        if (cart == null || cart.Count == 0)
        {
            return RedirectToAction("Index", "Cart");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        var cartJson = HttpContext.Session.GetString("Cart");

        if (string.IsNullOrEmpty(cartJson))
        {
            return RedirectToAction("Index", "Cart");
        }

        var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

        if (cart == null || cart.Count == 0)
        {
            return RedirectToAction("Index", "Cart");
        }
        
        if (!ModelState.IsValid)
        {
            return View(order);
        }

        order.TotalPrice = cart.Sum(item => item.Price * item.Quantity);
        order.CreatedAt = DateTime.Now;

        _context.Orders.Add(order);
        _context.SaveChanges();

        foreach (var item in cart)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = item.ProductId,
                ProductName = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };

            _context.OrderItems.Add(orderItem);
        }

        _context.SaveChanges();

        HttpContext.Session.Remove("Cart");

        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }
}