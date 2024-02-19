namespace OrderDeliveryHomework
{
    abstract class Delivery
    {
        public string shippingAddress { get; protected set; }
        public Delivery(string address)
        {
            shippingAddress = address;
        }
    }


    class HomeDelivery : Delivery
    {
        public HomeDelivery(string address) : base(address)
        {

        }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery(string address) : base(address)
        {

        }
    }

    class ShopDelivery : Delivery
    {
        public ShopDelivery(string address) : base(address)
        {

        }
    }


    class Order<TDelivery> where TDelivery : Delivery
    {
        public int Number { get; private set; }
        public string Description;
        public TDelivery delivery { get; protected set; }
        public Order(TDelivery delivery)
        {
            this.delivery = delivery;
            GenerateNumber();
        }


        public void DisplayAddress()
        {
            Console.WriteLine(delivery.shippingAddress);
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
            HomeDelivery delivery = new HomeDelivery("MyAdress");
            Order<Delivery> myOrder = new Order<Delivery>(delivery);
            myOrder.DisplayAddress();

            Environment.Exit(0);

        }
    }
}
