using Microsoft.AspNetCore.Mvc;

namespace project2.Models
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    // Thêm 2 thuộc tính này nếu muốn
    public string Color { get; set; }
    public string Material { get; set; }
}