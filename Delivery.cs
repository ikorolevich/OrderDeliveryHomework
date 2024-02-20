namespace OrderDeliveryHomework
{
    public abstract class Delivery
    {
        public bool IsCompleted { get; protected set; }
        public string ShippingAddress { get; protected set; }
        public double Price { get; protected set; }
        public Delivery(string address)
        {
            ShippingAddress = address;
            Price = CalculatePrice(ShippingAddress);
        }
        public void ChangeShippingAddress(string newAddress)
        {
            ShippingAddress = newAddress;
            Price = CalculatePrice(ShippingAddress);
        }
        private double CalculatePrice(string shippingAddress)
        {
            return 15;   //depending on shipping address;
        }
        public virtual void Complete()
        {
            IsCompleted = true;
        }
    }

    public class HomeDelivery : Delivery
    {
        public string ShippingCompany { get; protected set; }
        public HomeDelivery(string address, string shippingCompany) : base(address)
        {
            ShippingCompany = shippingCompany;
        }
        public override void Complete()
        {
            base.Complete();
        }
    }

    public class PickPointDelivery : Delivery
    {
        public string PickPointCompany { get; protected set; }
        public int PickPointNbr { get; protected set; }
        public PickPointDelivery(string address, string pickPointCompany, int pickPointNbr) : base(address)
        {
            PickPointCompany = pickPointCompany;
            PickPointNbr = pickPointNbr;
        }
        public override void Complete()
        {
            base.Complete();
        }
    }

    public class ShopDelivery : Delivery
    {
        public ShopDelivery(string address) : base(address)
        {

        }
        public override void Complete()
        {
            base.Complete();
        }
    }

}
