using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp6.Classes;
using WpfApp6.Models;

namespace WpfApp6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Spisok.ItemsSource = AppData.db.User.ToList();
        }

        private void Delit(object sender, RoutedEventArgs e)
        {
            var CurUser = Spisok.SelectedItem as User;
            AppData.db.User.Remove(CurUser);
            AppData.db.SaveChanges();
            Spisok.ItemsSource = AppData.db.User.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var users = AppData.db.User.ToList();
            // Фильтруем пользователей по FName
            var filteredUsers = users.Where(u => u.FName.ToLower().Contains(searchText)).ToList();

            Spisok.ItemsSource = new ObservableCollection<User>(filteredUsers);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox1.Text.ToLower();
            var _users = AppData.db.User.ToList();
            // Фильтруем пользователей по FName
            var filteredUsers = _users.Where(u => u.FName.ToLower().Contains(searchText)).ToList();

            // Обновляем ItemsSource для DataGrid
            Spisok.ItemsSource = new ObservableCollection<User>(filteredUsers);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SortByFName_Click(object sender, RoutedEventArgs e)
        {
            var users1 = AppData.db.User.ToList();
            // Сортируем пользователей по FName
            var sortedUsers = new List<User>(users1);
            sortedUsers.Sort((x, y) => string.Compare(x.FName, y.FName));

            Spisok.ItemsSource = sortedUsers; // Обновляем источник данных
        }
    }
}
