using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TheLastLibrary.Classess;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Linq;
using System.Windows.Shapes;
using Windows.Storage;


namespace TheLastLibrary.Services
{
    //
    /// <summary>
    /// here im creating 2 new Json Databases For each class , in the project folder
    /// </summary>
    public class JsonService
    {
        string _booksPath; // you can manually add a location for the folder
        string _gamesPath; // you can manually add a location for the folder
        private StorageFolder _folder;

        public JsonService()
        {
            _folder = ApplicationData.Current.LocalFolder;
            _gamesPath = System.IO.Path.Combine(_folder.Path, "GamesDb");
            _booksPath = System.IO.Path.Combine(_folder.Path, "BooksDb");

            if (!File.Exists(_gamesPath))
            {
                using (FileStream file = new FileStream(_gamesPath, FileMode.Create))
                {
                    file.Close();
                }
            }
            if (!File.Exists(_booksPath))
            {
                using (FileStream file = new FileStream(_booksPath, FileMode.Create))
                {
                    file.Close();
                }
            }
        }
   

        // i was trying to figure out which function is better for saving data,
        // i havnt figured out so i live it at that
        public List<Game> GeteGamesData()
        {
            try
            {
                string strConver = File.ReadAllText(_gamesPath);
                List<Game> data = JsonConvert.DeserializeObject<List<Game>>(strConver, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore
                });
                return data;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public List<Book> GeteBooksData()
        {
            if (File.Exists(_booksPath) == true)
            {
                var data = JsonConvert.DeserializeObject<List<Book>>
                (File.ReadAllText(_booksPath));
                if (data != null)
                {
                    
                    return data;
                }
                else
                    return new List<Book>();
            }
            else
            {
                return new List<Book>();
            }
        }


        public void SaveBooksData(List<Book> data)
        {
            string UpdatedList = ObjectToJson(data);
            WriteBooksFile(UpdatedList);
        }

        public void SaveGamesData(List<Game> data)
        {
            string UpdatedList = ObjectToJson(data);
            WriteGamesFile(UpdatedList);
        } 
        //write the string to the file
        private void WriteGamesFile(string data)
        {
            using (StreamWriter writer = new StreamWriter(_gamesPath))
            {
                writer.Write(data);
            }

        }
        //write the string to the file
        private void WriteBooksFile(string data)
        {
            using (StreamWriter writer = new StreamWriter(_booksPath))
            {
                writer.Write(data);
            }

        }

        //converting object to json string
        public string ObjectToJson(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

       



     
    }
}
