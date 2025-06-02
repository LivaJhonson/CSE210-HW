using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address addr2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer cust1 = new Customer("John Doe", addr1);
        Customer cust2 = new Customer("Jane Smith", addr2);

        // Create products for order 1
        Product prod1 = new Product("Laptop", "LP1001", 999.99, 1);
        Product prod2 = new Product("Mouse", "MS2002", 25.50, 2);

        // Create products for order 2
        Product prod3 = new Product("Keyboard", "KB3003", 45.75, 1);
        Product prod4 = new Product("Monitor", "MN4004", 200.00, 2);
        Product prod5 = new Product("USB Cable", "US5005", 10.00, 3);

        // Create orders and add products
        Order order1 = new Order(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        Order order2 = new Order(cust2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);
        order2.AddProduct(prod5);

        // Display order 1 details
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Order 1 Total Cost: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine();

        // Display order 2 details
        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Order 2 Total Cost: ${order2.CalculateTotalCost():0.00}");
    }
}
