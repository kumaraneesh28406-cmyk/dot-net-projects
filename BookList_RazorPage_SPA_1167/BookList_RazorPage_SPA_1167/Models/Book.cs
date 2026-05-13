using System.ComponentModel.DataAnnotations;


namespace Booklist_RazorPage_spa_1161.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public int Price { get; set; }

}
