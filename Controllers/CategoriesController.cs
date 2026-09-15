using BonWeb.Data;
using BonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BonWeb.Controllers;

public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();

        return View(categories);
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}