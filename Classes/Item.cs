using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastLibrary.Classes
{
    public abstract class Item
    {
        string _name;
        string _description;
        public static int counter { get; private set; }
        public readonly int _id;
        DateTime _created;
        double _price;
        int _discount;
        //public string PictureLink { get; }
        string _genre;
        int _quantity;

        public int ID { get { return _id; } }
        public string Name { get { return _name; } set { _name = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public int MinimumAge { get; }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public int Discount { get { return _discount; } set { _discount = value; } }
        public DateTime created { get; }
        public string Description { get { return _description; } set { _description = value; } }

        public Item(string name, string description, double price, int discount, int minimumAge, int quantity, string genre)
        {
            Name = name;
            Description = description;
            _created = created;
            Price = price;
            Discount = discount;
            MinimumAge = minimumAge;
            Quantity = quantity;
            _id = counter++;
            created = DateTime.Now;
            Genre = genre;
        }



        //public void AddToCount()
        //{
        //    counter++;
        //}

    }
}
