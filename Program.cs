namespace OrderDeliveryHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order<Delivery, Product>> orders = new List<Order<Delivery, Product>>(3);
            Product[] products = new Product[2];
            products[0] = new CellPhone("Galaxy Note 10", 700);
            products[1] = new Notebook("Lenovo t550", 2500);
            Delivery homeDelivery = new HomeDelivery("My Address", "Shipping Company");
            Order<Delivery, Product> HomeOrder = new Order<Delivery, Product>(homeDelivery, products);

            //Home order
            HomeOrder.Delivery.ChangeShippingAddress("New Address");
            HomeOrder.SetPaidAmount(3215);
            HomeOrder.IsOrderPaid();
            orders.Add(HomeOrder);

            //Pick point order
            Delivery pickPointDelivery = new PickPointDelivery("Pick Point Address", "Pick Point Company", 10);
            pickPointDelivery.NewMehod("Using Extension");     //Extension Testing
            Order<Delivery, Product> PickPointOrder = new Order<Delivery, Product>(pickPointDelivery, products);
            PickPointOrder.SetPaidAmount(3215);
            PickPointOrder.IsOrderPaid();
            orders.Add(PickPointOrder);

            //Shop Delivery
            Delivery shopDelivery = new ShopDelivery("Shop Address");
            Order<Delivery, Product> shopOrder = new Order<Delivery, Product>(shopDelivery, products);
            shopOrder.SetPaidAmount(3215);
            shopOrder.IsOrderPaid();
            orders.Add(shopOrder);

            Console.WriteLine();
            foreach (var order in orders)
            {
                Console.WriteLine("Order number = {0}", order.Number);
                Console.WriteLine("Total amount = {0}", order.TotalAmount);
                Console.WriteLine("Is order complete ? {0}", order.isCompleted);
                Console.WriteLine("List of products in the order:");
                order.DisplayOrderedProducts();

                Console.WriteLine();
            }
        }
    }
}
