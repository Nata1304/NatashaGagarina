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
using WpfApp6.Classes;
using WpfApp6.Models;

namespace WpfApp6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            CmbBoxRole.ItemsSource = AppData.db.Role.ToList();
        }

        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            var CurRole = CmbBoxRole.SelectedItem as Role;
            User pepl = new User()
            {
                Login = LoginTxb.Text,
                Password = PasswordTxb.Text,
                FName = FamilTxb.Text,
                MName = NameTxb.Text,
                LName = LNAmeTxb.Text,
                BDate = BDPicker.SelectedDate.Value,
                RoleID = CurRole.ID
            };
            AppData.db.User.Add(pepl);
            AppData.db.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
