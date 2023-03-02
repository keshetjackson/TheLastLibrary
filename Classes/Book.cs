using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastLibrary.Classes
{
    public enum BooksGenres
    {
        action,
        adventure,
        art,
        history,
        autobiography,
        anthology,
        biography,
        romance,
        business,
        childrens,
        crafts,
        classic,
        cookbook,
        comics,
        drama
    }
    public class Book : Item
    {
        public string Author { get; }
        public Book(string name, string description, double price, int discount, int minimumAge, int quantity, string genre, string author) : base(name, description, price, discount, minimumAge, quantity, genre)
        {
            Author = author;
        }
    }
}