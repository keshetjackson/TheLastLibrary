using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastLibrary.Classess
{
    /// <summary>
    /// abstract class forn practice
    /// </summary>
    public abstract class Item
    {
        string _name;
        string _description;
        public static int counter { get; private set; }
        public readonly int ID;
        DateTime _created;
        double _price;
        int _discount;
        string _genre;
        int _quantity;

        
        public string Name { get { return _name; } set { _name = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public int MinimumAge { get; }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public int Discount { get { return _discount; } set { _discount = value; } }
        public DateTime created { get; }
        public string Description { get { return _description; } set { _description = value; } }

        public double Price_After_Discount { get { return CalculateDiscount(); } }

        public Item(string name, string description, double price, int discount, int minimumAge, int quantity, string genre)
        {
            Name = name;
            Description = description;
            _created = created;
            Price = price;
            Discount = discount;
            MinimumAge = minimumAge;
            Quantity = quantity;
            ID = counter++;
            created = DateTime.Now;
            Genre = genre;
        }

        public double CalculateDiscount()
        {
           double DDiscount = (Price * Discount)/ 100;
            double tempP = Price - DDiscount;
            return tempP;
        }

        public override string ToString()
        {
            StringBuilder myString = new StringBuilder();
            myString.Append($"name: {Name}, \n Price: {_price}, \n discount: {Discount}, \n" +
                $" Price after Discount: {Price_After_Discount}, \n Minimum Age: {MinimumAge}, \n Quantity: {Quantity}, \n Genre: {Genre}");
            return myString.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
