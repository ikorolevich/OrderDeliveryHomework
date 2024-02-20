using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliveryHomework
{
    public abstract class Product
    {
        public string Brand { get; protected set; }
        public double Price { get; protected set; }
        public Product(string brand, double price)
        {
            Brand = brand;
            Price = price;

        }
    }
    public class Computers : Product
    {
        public Computers(string brand, double price) : base(brand, price)
        {
        }
    }
    public class Notebook : Computers
    {
        public Notebook(string brand, double price) : base(brand, price)
        {
        }
    }
    public class Phones : Product
    {
        public Phones(string brand, double price) : base(brand, price)
        {
        }
    }
    public class CellPhone : Phones
    {
        public CellPhone(string brand, double price) : base(brand, price)
        {
        }
    }
}
