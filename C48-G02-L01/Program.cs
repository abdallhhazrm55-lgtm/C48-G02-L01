// ====== Models (نفس الموجود في ListGenerator بتاع الكورس) ======
public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

public class Order
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
}

public class Customer
{
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public List<Order> Orders { get; set; }
}

class Program
{
    static void Main()
    {

        List<Product> ProductList = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai",            Category = "Beverages",  UnitPrice = 18m,   UnitsInStock = 39 },
            new Product { ProductID = 2, ProductName = "Chang",           Category = "Beverages",  UnitPrice = 19m,   UnitsInStock = 17 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup",   Category = "Condiments", UnitPrice = 10m,   UnitsInStock = 13 },
            new Product { ProductID = 4, ProductName = "Chef Anton's",    Category = "Condiments", UnitPrice = 22m,   UnitsInStock = 0  },
            new Product { ProductID = 5, ProductName = "Ikura",           Category = "Seafood",    UnitPrice = 31m,   UnitsInStock = 31 },
            new Product { ProductID = 6, ProductName = "Konbu",           Category = "Seafood",    UnitPrice = 6m,    UnitsInStock = 24 },
            new Product { ProductID = 7, ProductName = "Carnarvon Tigers",Category = "Seafood",    UnitPrice = 62.5m, UnitsInStock = 42 },
            new Product { ProductID = 8, ProductName = "Guaraná",         Category = "Beverages",  UnitPrice = 4.5m,  UnitsInStock = 20 },
        };

        List<Customer> CustomerList = new List<Customer>
        {
            new Customer { CustomerID = "ALFKI", CompanyName = "Alfreds", Orders = new List<Order>
                {
                    new Order { OrderID = 1, OrderDate = new DateTime(1996, 5, 1),  Total = 100 },
                    new Order { OrderID = 2, OrderDate = new DateTime(1997, 8, 25), Total = 200 },
                }},
            new Customer { CustomerID = "ANATR", CompanyName = "Ana Trujillo", Orders = new List<Order>
                {
                    new Order { OrderID = 3, OrderDate = new DateTime(1998, 3, 3),  Total = 300 },
                }},
        };

        //  1 
        Console.WriteLine(" Seafood products ");
        var q1 = ProductList.Where(p => p.Category == "Seafood");
        foreach (var p in q1)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        //  2 
        Console.WriteLine("\n Product names only ");
        var q2 = ProductList.Select(p => p.ProductName);
        foreach (var name in q2)
            Console.WriteLine(name);

        //  3 
        Console.WriteLine("\nSorted by UnitPrice asc ");
        var q3 = ProductList.OrderBy(p => p.UnitPrice);
        foreach (var p in q3)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        //  4 
        Console.WriteLine("\nUnitPrice between 10 and 30 ");
        var q4 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
        foreach (var p in q4)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        // 5 
        Console.WriteLine("\n In stock & Condiments");
        var q5 = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
        foreach (var p in q5)
            Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

        //  6 
        Console.WriteLine("\n Anonymous type");
        var q6 = ProductList.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });
        foreach (var item in q6)
            Console.WriteLine($"{item.Name} | {item.Price} | {item.StockStatus}");

        // 7 
        Console.WriteLine("\n Name with position (1-based) ");
        var q7 = ProductList.Select((p, index) => new { Position = index + 1, p.ProductName });
        foreach (var item in q7)
            Console.WriteLine($"{item.Position}. {item.ProductName}");

        //  8 
        Console.WriteLine("\nCategory asc, then UnitPrice desc ");
        var q8 = ProductList.OrderBy(p => p.Category)
                            .ThenByDescending(p => p.UnitPrice);
        foreach (var p in q8)
            Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice}");

        // 9 
        Console.WriteLine("\nBeverages sorted by UnitsInStock desc ");
        var q9 = ProductList.Where(p => p.Category == "Beverages")
                            .OrderByDescending(p => p.UnitsInStock);
        foreach (var p in q9)
            Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

        // 10 
        Console.WriteLine("\nOrders in 1997 or later ");
        var q10 = from c in CustomerList
                  from o in c.Orders
                  where o.OrderDate.Year >= 1997
                  select new { c.CustomerID, o.OrderDate };
        foreach (var item in q10)
            Console.WriteLine($"{item.CustomerID} - {item.OrderDate:yyyy-MM-dd}");

        // 11 
        Console.WriteLine("\nPosition alongside ProductName ");
        var q11 = ProductList.Select((p, i) => new { Index = i + 1, p.ProductName });
        foreach (var item in q11)
            Console.WriteLine($"{item.Index} - {item.ProductName}");

        //  12 
        Console.WriteLine("\nSort by length, then case-insensitive ");
        string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        var q12 = Arr.OrderBy(w => w.Length)
                     .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
        foreach (var w in q12)
            Console.WriteLine(w);

        //  13 

        Console.WriteLine("\nDigits whose 2nd letter is 'i' (reversed) ");
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var q13 = digits.Where(d => d.Length > 1 && d[1] == 'i')
                        .Reverse();
        foreach (var d in q13)
            Console.WriteLine(d);
    }
}