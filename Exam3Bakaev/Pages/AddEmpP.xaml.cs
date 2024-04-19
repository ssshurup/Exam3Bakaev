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

namespace Exam3Bakaev.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEmpP.xaml
    /// </summary>
    public partial class AddEmpP : Page
    {
        users context;

        public AddEmpP()
        {
            InitializeComponent();
            RoleCB.ItemsSource = App.DB.role.ToList();
            context = new users();
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HrManagerP());
        }

        private void AddEmpBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var RegUser = App.DB.users.Where(a => a.login == context.login);
                if(RegUser.Any())
                {
                    MessageBox.Show("Логин занят");
                    return;
                }
                var selectedRole = RoleCB.SelectedItem as role;
                context.roleId = selectedRole.id;
                App.DB.users.Add(context);
                App.DB.SaveChanges();
                MessageBox.Show("Успех");
                NavigationService.Navigate(new HrManagerP());

            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
