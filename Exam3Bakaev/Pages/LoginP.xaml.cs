using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Exam3Bakaev.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        users context;
        public LoginP()
        {
            InitializeComponent();
            context = new users();
            DataContext = context;
        }

        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            var loggedUser = App.DB.users.Where(a => a.login == context.login && a.password == context.password );
            if(loggedUser.Any() )
            {
                App.LoggedUser = loggedUser.First();
                if (App.LoggedUser.roleId == 1) NavigationService.Navigate(new HrManagerP());
                else if (App.LoggedUser.roleId == 2) NavigationService.Navigate(new CallCenterP());
                else if (App.LoggedUser.roleId == 3) NavigationService.Navigate(new RabotnikP());
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }


    }
}
