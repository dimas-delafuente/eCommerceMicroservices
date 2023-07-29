﻿namespace Shopping.Aggregator.Models;

public class Basket
{
    public string UserName { get; set; } = null!;
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    public decimal TotalPrice { get; set; }
}
