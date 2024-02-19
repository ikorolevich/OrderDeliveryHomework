namespace OrderDeliveryHomework
{
    public abstract class Delivery<TProduct> where TProduct : Product
    {
        public TProduct Product { get; protected set; }
        public string shippingAddress { get; protected set; }
        public Delivery(string address)
        {
            shippingAddress = address;
        }
        public Delivery(TProduct product, string shippingAddress)
        {
            Product = product;
            this.shippingAddress = shippingAddress;
        }
    }

    public abstract class Product
    {
        string brand;
        public Product(string brand)
        {
            this.brand = brand;
        }
    }
    public class Computers : Product  
    {
        public Computers(string brand) : base(brand)
        {
        }
    }
    public class Notebook: Product
    {
        public Notebook(string brand) : base(brand)
        {
        }
    }
    public class Phones : Product
    {
        public Phones(string brand) : base(brand)
        {
        }
    }
    public class CellPhone: Phones
    {
        public CellPhone(string brand) : base(brand)
        {
        }
    }

    public class HomeDelivery<TProduct> : Delivery<TProduct> where TProduct:Product
    {
        public HomeDelivery(string address, TProduct product) : base(address)
        {

        }
    }

    class PickPointDelivery<TProduct> : Delivery<TProduct> where TProduct : Product
    {
        public PickPointDelivery(string address) : base(address)
        {

        }
    }

    class ShopDelivery<TProduct> : Delivery<TProduct> where TProduct : Product
    {
        public ShopDelivery(string address) : base(address)
        {

        }
    }


    class Order<TDelivery> where TDelivery :Delivery<Product>
    {
        public int Number { get; private set; }
        public string Description;
        public TDelivery Delivery { get; protected set; }
       // public TProduct Product { get; protected set; }
        public Order(TDelivery delivery)
        {
            this.Delivery = delivery;
            GenerateNumber();
        }


        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.shippingAddress);
        }
        private void GenerateNumber()
        {
            Number = new Random().Next(1, 1000);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product SamsungCell = new CellPhone("Galaxy Note 10");
            HomeDelivery<Product> delivery = new HomeDelivery<Product>("MyAdress",SamsungCell);
            Order<Delivery> order = new(delivery);
            //Order<Delivery> myOrder = new Order<Delivery>(delivery);
            //myOrder.DisplayAddress();

            Environment.Exit(0);

        }
    }
}
