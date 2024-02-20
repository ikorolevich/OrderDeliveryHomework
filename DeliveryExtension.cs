namespace OrderDeliveryHomework
{
    public static class DeliveryExtension
    {
        public static void NewMehod(this Delivery delivery, string ToPrint)
        {
            PickPointDelivery pickPointDelivery = (PickPointDelivery)delivery;
            Console.WriteLine(ToPrint);
            Console.WriteLine(delivery.Price);
            Console.WriteLine(pickPointDelivery.PickPointNbr);

        }

    }
}
