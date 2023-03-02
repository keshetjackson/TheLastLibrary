using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TheLastLibrary.Services;
using System.Reflection;
using System.Data;
using Dapper;

namespace TheLastLibrary.Classes
{
    public class MainLibrary
    {


        public List<Item> Items;
        public List<Book> Books;
        public List<Game> Games;
        SqlService DbService;
        

        public MainLibrary()
        {
            DbService = new SqlService();
           RetrieveList();
        }

        public void AddBook(string name, string description, double price, int discount, int minimumAge,  int quantity, string genre, string author)
        {
            Books.Add(new Book(name, description, price, discount, minimumAge, quantity, genre, author));
            BookToDb(name, description, price, discount, minimumAge, quantity, genre, author);
        }
        public void AddGame(string name, string description, double price, int discount, int minimumAge, int quantity, string genre)
        {
            Games.Add(new Game(name, description, price, discount, minimumAge, quantity, genre));
            GameToDb(name, description, price, discount, minimumAge, quantity, genre);
        }

       //public void DataToList()
       // {
       //     using (DbService._connection)
       //     using (var reader = DbService._connection.ExecuteReader("SELECT * FROM LibraryTable WHERE Type = Book")) 
       //     {
       //         var ItemsContractParse = reader.GetRowParser<Book>();
       //         while (reader.Read())
       //         {
       //             Items.Add(ItemsContractParse(reader));
       //         }
       //     }
       // }

        public void RetrieveList()
        {
            using (DbService._connection)
            {
                var ItemsData = DbService._connection.Query<Book>("SELECT * FROM BooksTable" );
                Books = ItemsData.ToList();
            }
        }

         public List<Item> GetItems()
        {
            return Items;
        }

         void UpdateName(Item i, string NewName)
        {
            i.Name = NewName;
        }
         void UpdatePrice(Item i, double NewPrice)
        {
            i.Price = NewPrice;
        }
         void UpdateDiscount(Item i, int NewDiscount)
        {
            i.Discount = NewDiscount;
        }
         void UpdateQuantity(Item i, int NewQuantity)
        {
            i.Quantity = NewQuantity;
        }


         Item SearchByName(string name)
        {
            foreach (Item i in Items)
            {
                if (i == null) throw new ArgumentNullException();
                if (i.Name == name) return i;
            }
            return null;
        }
         Item SearchById(int id)
        {
            foreach (Item i in Items)
            {
                if (i == null) throw new ArgumentNullException();
                if (i.ID == id) return i;
            }
            return null;
        }

         Item SearchByPriceRange(int min, int max)
        {
            foreach (Item i in Items)
            {
                if (i == null) throw new ArgumentNullException();
                if (i.Price <= max && i.Price >= min) return i;
            }
            return null;
        }
         Item SearchByMinimumAge(int min)
        {
            foreach (Item i in Items)
            {
                if (i == null) throw new ArgumentNullException();
                if (i.MinimumAge <= min && i.Price >= min) return i;
            }
            return null;
        }

         Item SearchByGenre(string genre)
        {
            foreach (Item i in Items)
            {
                if (i == null) throw new ArgumentNullException();
                if (i.Genre == genre) return i;
            }
            return null;
        }

        public void BookToDb(string name, string description, double price, int discount, int minimumAge, int quantity, string genre, string author)
        {
            DbService._connection.Open();
            DbService.SqlQuery("INSERT INTO BooksTable (Name,Price,Genre,MinimumAge,Quantity,Discount,Created,Description,Author,Type)" +
                " VALUES (@Name,@Price,@Genre,@MinimumAge,@Quantity,@Discount,@Created,@Description,@author,@Type)");
            DbService._cmd.Parameters.Add("@Name", name);
            DbService._cmd.Parameters.Add("@Price", price);
            DbService._cmd.Parameters.Add("@Genre", genre);
            DbService._cmd.Parameters.Add("@MinimumAGe", minimumAge);
            DbService._cmd.Parameters.Add("@Quantity", quantity);
            DbService._cmd.Parameters.Add("@Discount", discount);
            DbService._cmd.Parameters.Add("@Created", SearchByName(name).created);
            DbService._cmd.Parameters.Add("@Description", description);
            DbService._cmd.Parameters.Add("@Author", author);
            DbService._cmd.Parameters.Add("@Type", SearchByName(name).GetType().ToString());

            DbService._cmd.ExecuteNonQuery();
            DbService._connection.Close();
        }

        public void GameToDb(string name, string description, double price, int discount, int minimumAge, int quantity,string genre)
        {
            DbService._connection.Open();
            DbService.SqlQuery("INSERT INTO GamesTable (Name,Price,Genre,MinimumAge,Quantity,Discount,Created,Description,Type)" +
                " VALUES (@Name,@Price,@Genre,@MinimumAge,@Quantity,@Discount,@Created,@Description,@Type)");
            DbService._cmd.Parameters.Add("@Name", name);
            DbService._cmd.Parameters.Add("@Price", price);
            DbService._cmd.Parameters.Add("@Genre", genre);
            DbService._cmd.Parameters.Add("@MinimumAGe", minimumAge);
            DbService._cmd.Parameters.Add("@Quantity", quantity);
            DbService._cmd.Parameters.Add("@Discount", discount);
            DbService._cmd.Parameters.Add("@Created", SearchByName(name).created);
            DbService._cmd.Parameters.Add("@Description", description);
            DbService._cmd.Parameters.Add("@Type", SearchByName(name).GetType().ToString());


            DbService._cmd.ExecuteNonQuery();
            DbService._connection.Close();
        }


        //public void BookToDb(string name)
        //{
        //    Book B = (Book)SearchByName(name);
        //    foreach (PropertyInfo prop in typeof(Book).GetProperties())
        //    {
        //        foreach(DataColumn Dc in DbService._dataTable.Columns)
        //        {
        //            if (Dc.ColumnName == prop.Name)
        //            {
        //                DbService._connection.Open();
        //                DbService.SqlQuery($"INSERT INTO LibraryTable ({Dc.ColumnName}) VALUES {prop.GetValue(B)}");
        //                DbService._connection.Close();
        //            }
        //        }
        //    }
        //}



    }
  
}
