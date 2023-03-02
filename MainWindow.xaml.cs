using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using TheLastLibrary.Classess;

namespace TheLastLibrary

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainLibrary library;

        public MainWindow()
        {
            InitializeComponent();
            library = new MainLibrary();
            LoadGrid();
        }
        string password = "admin";
        OnView ItemsOnView = OnView.All;


        public void LoadGrid()
        {
            DataView.ItemsSource = library.GetItems();
        }




        private void AdminB_Click(object sender, RoutedEventArgs e)
        {

        }

        //operations are enabled only for admin
        public void AdminMode()
        {
            MessageBox.Show("access granted. welcome back manager!");
            DeleteB.IsEnabled = true;
            DeleteB.Visibility = Visibility.Visible;
            AddBookB.IsEnabled = true;
            AddBookB.Visibility = Visibility.Visible;
            SaveChangesB.IsEnabled = true;
            SaveChangesB.Visibility = Visibility.Visible;
            AdminB.IsEnabled = false;
            PassWordBox.IsEnabled = false;
            AdminB.IsEnabled = false;
        }

        //checks for enter in the password box
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (PassWordBox.Text == password) AdminMode();
                else
                {
                    MessageBox.Show("wrong password");
                    PassWordBox.Clear();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        //exit button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //add Book / Game button
        private void AddBookB_Click(object sender, RoutedEventArgs e)
        {

            AddBookWindow addbookwindow = new AddBookWindow(library, DataView);
            addbookwindow.Show();

        }

     
        private void DataView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // save changes button
        private void SaveChangesB_Click(object sender, RoutedEventArgs e)
        {
           if (DataView.ItemsSource == library.Books)
            {
                library.UpdateBooks();
                MessageBox.Show("changes have been saved!");
            }
            if (DataView.ItemsSource == library.Games)
            {
                library.UpdateGames();
                MessageBox.Show("changes have been saved!");
            }
            if (DataView.ItemsSource == library.Items) MessageBox.Show("please update from games or books list");
        }

        // show books list
        private void BooksB_Click(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = library.Books;
            ItemsOnView = OnView.Books;
        }

        //show games list
        private void GamesB_Click(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = library.Games;
            ItemsOnView= OnView.Games;
        }

        //show all items list
        private void ItemsB_Click(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = library.Items;
        }

        //delete item from a certain list 
        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {
           if (ItemsOnView == OnView.Books)
            {
                library.Books.Remove((Book)DataView.SelectedItem);
                library.UpdateBooks();
                library.RefReshListData();
                DataView.ItemsSource = library.Books;
            }
            if (ItemsOnView == OnView.Games)
            {
                library.Games.Remove((Game)DataView.SelectedItem);
                library.UpdateGames();
                library.RefReshListData();
                DataView.ItemsSource = library.Games;
            }
            if (ItemsOnView == OnView.All)
            {
                MessageBox.Show("please delete item from a specific list (Books/Games)");
            }
            
        }

        //dynamic sort by prices
        private void MaxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            int max;
            int min;
            if (MinPrice.Text == string.Empty)
                min = 0;
            else min = int.Parse(MinPrice.Text);
            if (MaxPrice.Text == string.Empty)
                max = 100;
            else max = int.Parse(MaxPrice.Text);
           DataView.ItemsSource = library.SearchByPriceRange(min, max);
        }

        private void MinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

            int max;
            int min;
            if (MinPrice.Text == string.Empty)
                min = 0;
            else min = int.Parse(MinPrice.Text);
            if (MaxPrice.Text == string.Empty)
                max = 100;
            else max = int.Parse(MaxPrice.Text);
            DataView.ItemsSource = library.SearchByPriceRange(min, max);
        }

       
        //dynamic sort by name
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            DataView.ItemsSource = library.SearchByName(SearchBox.Text);
        }

      
    }
    public enum OnView
    {
        Books,
        Games,
        All
    }
}
