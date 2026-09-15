using BonWeb.Data;
using BonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BonWeb.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? categoryId, string search)
    {
        var products = _context.Products
            .Include(p => p.Category)
            .AsQueryable();

        if (categoryId != null)
        {
            products = products.Where(p => p.CategoryId == categoryId);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            products = products.Where(p =>
                p.Name.Contains(search) ||
                p.Description.Contains(search));
        }

        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.SelectedCategory = categoryId;
        ViewBag.Search = search;

        return View(products.ToList());
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();

        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }else return View(product);
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        var product = _context.Products.FirstOrDefault(p =>  p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p =>  p.Id == id);

        if (product == null)
        {
            return NotFound();
        }else return View(product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
}