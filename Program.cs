namespace OrderDeliveryHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[2];
            products[0] = new CellPhone("Galaxy Note 10", 700);
            products[1] = new Notebook("Lenovo t550", 2500);
            Delivery homeDelivery = new HomeDelivery("My Address", "Shipping Company");
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
