namespace BonWeb.Models;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Внесете име и презиме.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Внесете email адреса.")]
    [EmailAddress(ErrorMessage = "Внесете валидна email адреса.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Внесете телефон.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Внесете адреса.")]
    public string Address { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = "Нова";

    public List<OrderItem> Items { get; set; }
}