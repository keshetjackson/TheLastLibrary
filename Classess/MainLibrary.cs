using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastLibrary.Services;
using System.Linq;
using System.ComponentModel;

namespace TheLastLibrary.Classess
{
    public class MainLibrary
    {

        public List<Item> Items;
        public List<Book> Books;
        public List<Game> Games = new List<Game>();
        JsonService DataBaseService;

        public MainLibrary()
        {
            DataBaseService = new JsonService();
            RefReshListData();
           
        }

        // add to the books list new book and save it to the database
        public void AddBook(string name, string description, double price, int discount, int minimumAge, int quantity, string genre, string author)
        {
            try
            {
            Books.Add(new Book(name, description, price, discount, minimumAge, quantity, genre, author));
            DataBaseService.SaveBooksData(Books);

            }
            catch (System.NullReferenceException nrx)
            {

                throw new Exception("what null?");
            }
        }

        // add to the games list new book and save it to the database
        public void AddGame(string name, string description, double price, int discount, int minimumAge, int quantity, string genre, string creator)
        {
            try
            {
            Games.Add(new Game(name, description, price, discount, minimumAge, quantity, genre, creator));
            DataBaseService.SaveGamesData(Games);

            }
            catch (System.NullReferenceException nrx)
            {

                throw new Exception("what null?");
            }
        }

        
        public void UpdateBooks()
        {
            DataBaseService.SaveBooksData(Books);
        }

        public void UpdateGames()
        {
            DataBaseService.SaveGamesData(Games);
        }

        

   
        //loading the lists from the database then cast them to item type to create 1 list for all items
        public void RefReshListData()
        {
            Items = new List<Item>();
            
            
            if (DataBaseService.GeteBooksData() == null)
            {
                Books = new List<Book>();
            }
            else
            {
                Books = DataBaseService.GeteBooksData();
            }
            if (DataBaseService.GeteGamesData() == null)
            {
                Games = new List<Game>();
            }
            else
            {
                Games = DataBaseService.GeteGamesData();
            }
                    
            var bb = new List<Item>();
            var gg = new List<Item>();
            try
            {
                if (Books != null)
                {
                        bb = Books.Cast<Item>().ToList();
                }
                if (Games != null)
                {
                    gg = Games.Cast<Item>().ToList();
                }
                if (Items == null)
                    Items = new List<Item>();
            Items.AddRange(gg);
            Items.AddRange(bb);

            }
            catch (ArgumentNullException anx)
            {

                throw new Exception("what");
            }

           
        }

        public List<Item> GetItems()
        {
            return Items;
        }

        // search by price range 
        public List<Item> SearchByPriceRange(int min = 0, int max = 0)
        {
            var results = Items.Where(i => i.Price < max && i.Price > min).ToList();            
            return results;           
        }



        //search By Name
        public List<Item> SearchByName(string name)
        {
            var results = new List<Item>();
            results = Items.Where(x => x.Name.Contains(name)).ToList();
            return results;
        }




    }
}
