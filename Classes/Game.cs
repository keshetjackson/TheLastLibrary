using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastLibrary.Classes
{
    public enum GamesGenres
    {
        Single,
        strategy,
        race,
        elimination,
        economics,
        word,
        cooperative,
        childrens,
        mystery,
        magic,
        sport,
    }
    public class Game : Item
    {
        public Game(string name, string description, double price, int discount, int minimumAge, int quantity,string genre) : base(name, description, price, discount, minimumAge, quantity, genre)
        {
        }
    }
}
