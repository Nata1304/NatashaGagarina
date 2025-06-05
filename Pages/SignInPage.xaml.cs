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

namespace WpfApp6.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.User.FirstOrDefault
               (u => u.Login == TxbLogin.Text && u.Password == TxbPassword.Text);
            if (CurrentUser == null)
            {
                MessageBox.Show("Такого пользователя нет в базе данных");
            }
            else
            {
                switch (CurrentUser.RoleID)
                {
                    case 1:
                        NavigationService.Navigate(new AdminPage());
                        break;
                    case 2:
                        NavigationService.Navigate(new UserPage());
                        break;
                }
            }
        }
    }
}
