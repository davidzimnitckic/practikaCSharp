using System;

abstract class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalAmount { get; set; }

    public Order(int id, string name, double amount)
    {
        OrderId = id;
        CustomerName = name;
        TotalAmount = amount;
    }

    public abstract void ShowInfo();
}

sealed class OnlineOrder : Order
{
    public string DeliveryAddress { get; set; }

    public OnlineOrder(int id, string name, double amount, string address)
        : base(id, name, amount)
    {
        DeliveryAddress = address;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Online] ID: {OrderId}, Клиент: {CustomerName}, Сумма: {TotalAmount}, Адрес: {DeliveryAddress}");
    }
}

sealed class InStoreOrder : Order
{
    public string StoreLocation { get; set; }

    public InStoreOrder(int id, string name, double amount, string location)
        : base(id, name, amount)
    {
        StoreLocation = location;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Store] ID: {OrderId}, Клиент: {CustomerName}, Сумма: {TotalAmount}, Магазин: {StoreLocation}");
    }
}

class Store
{
    private Order[] orders;

    public Store(Order[] orders)
    {
        this.orders = orders;
    }

    public Order GetLargestOrder()
    {
        Order maxOrder = orders[0];

        foreach (var order in orders)
        {
            if (order.TotalAmount > maxOrder.TotalAmount)
            {
                maxOrder = order;
            }
        }

        return maxOrder;
    }

    public Order[] GetOrdersByCustomer(string customerName)
    {
        int count = 0;

        foreach (var order in orders)
        {
            if (order.CustomerName == customerName)
                count++;
        }

        Order[] result = new Order[count];
        int index = 0;

        foreach (var order in orders)
        {
            if (order.CustomerName == customerName)
            {
                result[index] = order;
                index++;
            }
        }

        return result;
    }
    public void ShowAll()
    {
        foreach (var order in orders)
        {
            order.ShowInfo();
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        Order[] orders = new Order[]
        {
            new OnlineOrder(1, "Иван", 150.5, "Москва"),
            new InStoreOrder(2, "Анна", 200.0, "Берлин"),
            new OnlineOrder(3, "Иван", 300.0, "Питер"),
            new InStoreOrder(4, "Олег", 120.0, "Минск")
        };

        Store store = new Store(orders);

        Console.WriteLine("Все заказы:");
        store.ShowAll();

        Console.WriteLine("Самый дорогой заказ:");
        var largest = store.GetLargestOrder();
        largest.ShowInfo();

        Console.WriteLine();

        Console.WriteLine("Заказы клиента Иван:");
        var ivanOrders = store.GetOrdersByCustomer("Иван");

        foreach (var order in ivanOrders)
        {
            order.ShowInfo();
        }
    }
}