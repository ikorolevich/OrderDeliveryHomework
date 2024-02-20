namespace OrderDeliveryHomework
{

    //public abstract class Delivery
    //{
    //    public bool IsCompleted { get; protected set; }
    //    public string ShippingAddress { get; protected set; }
    //    public double Price { get; protected set; }
    //    public Delivery(string address)
    //    {
    //        ShippingAddress = address;
    //        Price = CalculatePrice(ShippingAddress);
    //    }
    //    public void ChangeShippingAddress(string newAddress)
    //    {
    //        ShippingAddress = newAddress;
    //        Price = CalculatePrice(ShippingAddress);
    //    }
    //    private double CalculatePrice(string shippingAddress)
    //    {
    //        return 15;   //depending on shipping address;
    //    }
    //    public virtual void Complete()
    //    {
    //        IsCompleted = true;
    //    }

    //}

    //public abstract class Product
    //{
    //    public string Brand { get; protected set; }
    //    public double Price { get; protected set; }
    //    public Product(string brand, double price)
    //    {
    //        Brand = brand;
    //        Price = price;

    //    }
    //}
    //public class Computers : Product
    //{
    //    public Computers(string brand, double price) : base(brand, price)
    //    {
    //    }
    //}
    //public class Notebook : Computers
    //{
    //    public Notebook(string brand, double price) : base(brand, price)
    //    {
    //    }
    //}
    //public class Phones : Product
    //{
    //    public Phones(string brand, double price) : base(brand, price)
    //    {
    //    }
    //}
    //public class CellPhone : Phones
    //{
    //    public CellPhone(string brand, double price) : base(brand, price)
    //    {
    //    }
    //}

    //public class HomeDelivery : Delivery
    //{
    //    public string ShippingCompany { get; protected set; }
    //    public HomeDelivery(string address, string shippingCompany) : base(address)
    //    {
    //        ShippingCompany = shippingCompany;
    //    }
    //    public override void Complete()
    //    {
    //        base.Complete();
    //    }
    //}

    //class PickPointDelivery : Delivery
    //{
    //    public string PickPointCompany { get; protected set; }
    //    public int PickPointNbr { get; protected set; }
    //    public PickPointDelivery(string address, string pickPointCompany, int pickPointNbr) : base(address)
    //    {
    //        PickPointCompany = pickPointCompany;
    //        PickPointNbr = pickPointNbr;
    //    }
    //    public override void Complete()
    //    {
    //        base.Complete();
    //    }
    //}

    //class ShopDelivery : Delivery
    //{
    //    public ShopDelivery(string address) : base(address)
    //    {

    //    }
    //    public override void Complete()
    //    {
    //        base.Complete();
    //    }
    //}

    //class Order<TDelivery, TProduct> where TDelivery : Delivery where TProduct : Product
    //{
    //    public delegate void OrderPaid();
    //    public event OrderPaid Paid;
    //    public int Number { get; private set; }
    //    public bool isCompleted { get; private set; }
    //    public string Description;
    //    public double TotalAmount { get; protected set; }
    //    public double PaidAmmount { get; protected set; }
    //    public TDelivery Delivery { get; protected set; }
    //    public TProduct[] Products { get; protected set; }
    //    // public TProduct Product { get; protected set; }
    //    public Order(TDelivery delivery, TProduct[] products)
    //    {
    //        this.Delivery = delivery;
    //        this.Products = products;
    //        GenerateNumber();
    //        TotalAmount = SetTotalAmount(Products, Delivery);
    //    }


    //    public void DisplayAddress()
    //    {
    //        Console.WriteLine(Delivery.ShippingAddress);
    //        Console.WriteLine();
    //    }
    //    public void DisplayOrderedProducts()
    //    {
    //        foreach (var product in Products)
    //        {
    //            Console.WriteLine("Product is {0}, Price is{1}", product.Brand, product.Brand);
    //            Console.WriteLine();
    //        }
    //    }
    //    private void GenerateNumber()
    //    {
    //        Number = new Random().Next(1, 1000);
    //    }
    //    private double SetTotalAmount(TProduct[] products, TDelivery delivery)
    //    {
    //        double sum = 0;
    //        foreach (var product in products)
    //        {
    //            sum += product.Price;
    //        }
    //        sum += delivery.Price;

    //        return sum;

    //    }
    //    public void SetPaidAmount(double amount)
    //    {
    //        PaidAmmount = amount;
    //    }
    //    public void Complete()
    //    {
    //        isCompleted = true;
    //    }
    //    public void IsOrderPaid()
    //    {
    //        if (TotalAmount == PaidAmmount)
    //        {
    //            Paid += Delivery.Complete;
    //            Paid += Complete;
    //            Paid.Invoke();
    //        }
    //    } 
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[2];
            products[0] = new CellPhone("Galaxy Note 10", 700);
            products[1] = new Notebook("Lenovo t550", 2500);
            Delivery homeDelivery = new HomeDelivery("My Address","Shipping Company");
            Order<Delivery, Product> HomeOrder = new Order<Delivery, Product>(homeDelivery, products);

            //Home order
            HomeOrder.Delivery.ChangeShippingAddress("New Address");
            HomeOrder.DisplayAddress();
            HomeOrder.DisplayOrderedProducts();
            HomeOrder.SetPaidAmount(3215);
            HomeOrder.IsOrderPaid();

            //Pick up order
            Delivery pickPointDelivery = new PickPointDelivery("Pick Point Address", "Pick Point Company", 10);
            Order<Delivery, Product> PickPointOrder = new Order<Delivery, Product>(pickPointDelivery, products);
            PickPointOrder.SetPaidAmount(3215);
            PickPointOrder.IsOrderPaid();

            Environment.Exit(0);

        }
    }
}
