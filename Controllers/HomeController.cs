using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BonWeb.Models;
using BonWeb.Services;

namespace BonWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Contact(ContactForm model)
    {
        _emailService.SendEmail(
            model.Name,
            model.Email,
            model.Phone,
            model.Subject,
            model.Message
        );

        ViewBag.Message = "Пораката е успешно испратена.";

        return View();
    }
    private readonly EmailService _emailService;
    public HomeController(EmailService emailService)
    {
        _emailService = emailService;
    }
}