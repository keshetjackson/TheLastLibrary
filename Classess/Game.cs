using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastLibrary.Classess
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
        public string Creator { get; }
        public Game(string name, string description, double price, int discount, int minimumAge, int quantity, string genre, string creator) : base(name, description, price, discount, minimumAge, quantity, genre)
        {
            Creator = creator;
        }
    }
}
