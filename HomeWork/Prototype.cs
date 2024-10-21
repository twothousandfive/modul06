using System;
public class Product : ICloneable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Реализация глубокого клонирования
    public object Clone()
    {
        return new Product(this.Name, this.Price, this.Quantity);
    }

    public override string ToString()
    {
        return $"{Name}, Price: {Price}, Quantity: {Quantity}";
    }
}
// Класс Скидка
public class Discount : ICloneable
{
    public string Description { get; set; }
    public decimal DiscountAmount { get; set; }

    public Discount(string description, decimal discountAmount)
    {
        Description = description;
        DiscountAmount = discountAmount;
    }

    // Реализация глубокого клонирования
    public object Clone()
    {
        return new Discount(this.Description, this.DiscountAmount);
    }

    public override string ToString()
    {
        return $"{Description}, Amount: {DiscountAmount}";
    }
}

// Класс Заказ
public class Order : ICloneable
{
    public List<Product> Products { get; set; }
    public decimal ShippingCost { get; set; }
    public Discount OrderDiscount { get; set; }
    public string PaymentMethod { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }

    // Добавление товара в заказ
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    // Реализация глубокого клонирования
    public object Clone()
    {
        // Создаем новый заказ и клонируем товары, скидки и другие параметры
        Order clonedOrder = new Order
        {
            ShippingCost = this.ShippingCost,
            OrderDiscount = this.OrderDiscount != null ? (Discount)this.OrderDiscount.Clone() : null,
            PaymentMethod = this.PaymentMethod
        };

        // Клонируем каждый продукт в заказе
        foreach (var product in this.Products)
        {
            clonedOrder.AddProduct((Product)product.Clone());
        }

        return clonedOrder;
    }
}
