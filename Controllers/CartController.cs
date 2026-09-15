using System.Text.Json;
using BonWeb.Data;
using BonWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BonWeb.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult AddToCart(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var cartJson = HttpContext.Session.GetString("Cart");

        List<CartItem> cart;

        if (string.IsNullOrEmpty(cartJson))
        {
            cart = new List<CartItem>();
        }
        else
        {
            cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        var existingItem = cart.FirstOrDefault(c => c.ProductId == id);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Quantity = 1
            });
        }

        HttpContext.Session.SetString(
            "Cart",
            JsonSerializer.Serialize(cart)
        );

        return RedirectToAction("Index", "Products");
    }
    public IActionResult Index()
    {
        var cartJson = HttpContext.Session.GetString("Cart");

        List<CartItem> cart;

        if (string.IsNullOrEmpty(cartJson))
        {
            cart = new List<CartItem>();
        }
        else
        {
            cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        return View(cart);
    }
    
    public IActionResult Increase(int id)
    {
        var cartJson = HttpContext.Session.GetString("Cart");

        if (string.IsNullOrEmpty(cartJson))
        {
            return RedirectToAction("Index");
        }

        var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            item.Quantity++;
        }

        HttpContext.Session.SetString(
            "Cart",
            JsonSerializer.Serialize(cart)
        );

        return RedirectToAction("Index");
    }
    public IActionResult Decrease(int id)
    {
        var cartJson = HttpContext.Session.GetString("Cart");

        if (string.IsNullOrEmpty(cartJson))
        {
            return RedirectToAction("Index");
        }

        var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            item.Quantity--;

            if (item.Quantity <= 0)
            {
                cart.Remove(item);
            }
        }

        HttpContext.Session.SetString(
            "Cart",
            JsonSerializer.Serialize(cart)
        );

        return RedirectToAction("Index");
    }
    public IActionResult Remove(int id)
    {
        var cartJson = HttpContext.Session.GetString("Cart");

        if (string.IsNullOrEmpty(cartJson))
        {
            return RedirectToAction("Index");
        }

        var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            cart.Remove(item);
        }

        HttpContext.Session.SetString(
            "Cart",
            JsonSerializer.Serialize(cart)
        );

        return RedirectToAction("Index");
    }
}