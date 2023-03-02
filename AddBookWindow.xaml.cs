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
using System.Windows.Shapes;
using System.Data.SqlClient;
using Uno.Extensions;
//using classLibrary;
using TheLastLibrary.Classess;


namespace TheLastLibrary
{
   
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        MainLibrary library;
        DataGrid dataView;


        public AddBookWindow(MainLibrary l, DataGrid d)
        {
            library = l;
            dataView = d;
            InitializeComponent();
        }
        public AddBookWindow()
        {
            InitializeComponent();
        }
        
       

  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        //checks for valid fields in the creation
        public bool IsValid()
        {
            double tempDouble;
            int tempInt;
            if (NameField.Text == string.Empty && NameField.Text == null)
            {
                MessageBox.Show("Name is missing", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (PriceField.Text == string.Empty && double.TryParse(PriceField.Text,out tempDouble) == false)
            {
                MessageBox.Show("Price is missing", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (DiscountField.Text == string.Empty && int.TryParse(DiscountField.Text,out tempInt) == false)
            {
                MessageBox.Show("Discount is missing", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (MinimymAgeField.Text == string.Empty && !int.TryParse(MinimymAgeField.Text, out tempInt) == false)
            {
                MessageBox.Show("MinimumAge is missing", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (DescriptionField.Text == string.Empty && DescriptionField.Text != null)
            {
                MessageBox.Show("Description is missing", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (GenreBox.SelectedItem.ToString() == string.Empty && GenreBox.SelectedItem.ToString() == null)
            {
                MessageBox.Show("Description is missing", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
      

        //checks for the type of the item and layout different fields for each type
        private void BookTypeB_Checked(object sender, RoutedEventArgs e)
        {
            if (BookTypeB.IsChecked == true)
            {
                AuhorField.Tag = "Enter Author";
                AuthorLabel.Content = "author:";
                GenreBox.Items.Clear();
                GenreBox.Items.AddRange(Enum.GetNames(typeof(BooksGenres)));
            }
        }

        private void GameTypeB_Checked(object sender, RoutedEventArgs e)
        {
            if (GameTypeB.IsChecked == true)
            {
                AuhorField.Tag = "Enter Creator";
                AuthorLabel.Content = "Creator:";
                GenreBox.Items.Clear();
                GenreBox.Items.AddRange(Enum.GetNames(typeof(GamesGenres)));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearAllFields();
            
        }

        //add button combine validation and creation
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (IsValid())
            {

            string name = NameField.Text;
            string description = DescriptionField.Text;
            double price = Double.Parse(PriceField.Text);
            int discount = int.Parse(DiscountField.Text);
            int minimumAge = int.Parse(MinimymAgeField.Text);
            int quantity = int.Parse(QunatityField.Text);
            string author = AuhorField.Text;
            string genre = GenreBox.SelectedItem.ToString();

                if (BookTypeB.IsChecked == true)
                {

                    library.AddBook(name, description, price, discount, minimumAge, quantity, genre, author);
                }
                if (GameTypeB.IsChecked == true)
                {
                    try
                    {

                      library.AddGame(name, description, price, discount, minimumAge, quantity, genre, author);
                    }
                    catch (System.NullReferenceException nrx)
                    {

                        throw new Exception("what the fck is null");
                    }
                }
                ClearAllFields();
                library.RefReshListData();
                dataView.ItemsSource = library.GetItems();
                this.Hide();
            }

        }

        public void ClearAllFields()
        {
            NameField.Clear();
            PriceField.Clear();
            DescriptionField.Clear();
            MinimymAgeField.Clear();
            DiscountField.Clear();
            GenreBox.Items.Clear();
            AuhorField.Clear();
        }

     
    }
}
