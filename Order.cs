namespace OrderDeliveryHomework
{
    class Order<TDelivery, TProduct> where TDelivery : Delivery where TProduct : Product
    {
        public delegate void OrderPaid();
        public event OrderPaid Paid;
        public int Number { get; private set; }
        public bool isCompleted { get; private set; }
        public string Description;
        public double TotalAmount { get; protected set; }
        public double PaidAmmount { get; protected set; }
        public TDelivery Delivery { get; protected set; }
        public TProduct[] Products { get; protected set; }
        // public TProduct Product { get; protected set; }
        public Order(TDelivery delivery, TProduct[] products)
        {
            this.Delivery = delivery;
            this.Products = products;
            GenerateNumber();
            TotalAmount = SetTotalAmount(Products, Delivery);
        }


        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.ShippingAddress);
            Console.WriteLine();
        }
        public void DisplayOrderedProducts()
        {
            foreach (var product in Products)
            {
                Console.WriteLine("Product is {0}, Price is{1}", product.Brand, product.Brand);
                Console.WriteLine();
            }
        }
        private void GenerateNumber()
        {
            Number = new Random().Next(1, 1000);
        }
        private double SetTotalAmount(TProduct[] products, TDelivery delivery)
        {
            double sum = 0;
            foreach (var product in products)
            {
                sum += product.Price;
            }
            sum += delivery.Price;

            return sum;

        }
        public void SetPaidAmount(double amount)
        {
            PaidAmmount = amount;
        }
        public void Complete()
        {
            isCompleted = true;
        }
        public void IsOrderPaid()
        {
            if (TotalAmount == PaidAmmount)
            {
                Paid += Delivery.Complete;
                Paid += Complete;
                Paid.Invoke();
            }
        }
    }
}
