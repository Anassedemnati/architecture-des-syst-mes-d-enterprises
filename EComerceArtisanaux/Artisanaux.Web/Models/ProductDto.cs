﻿namespace Artisanaux.Web.Models;

public class ProductDto
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public double Price { get; set; }
    public string? CategoryName { get; set; }
    public string? ImageURL { get; set; }
}
