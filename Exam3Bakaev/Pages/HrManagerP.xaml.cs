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
    /// Логика взаимодействия для HrManagerP.xaml
    /// </summary>
    public partial class HrManagerP : Page
    {
        users context;
        public HrManagerP()
        {
            InitializeComponent();
            EmployeeDG.ItemsSource = App.DB.users.ToList();
            RoleCB.ItemsSource = App.DB.role.ToList();
            context = new users();
            DataContext = context;
        }

        private void AddEmpBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmpP());
        }

        private void EditEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmployeeDG.SelectedItem as users;
            if(selectedEmp != null) NavigationService.Navigate(new EditEmpP(selectedEmp));
            else MessageBox.Show("Нужно выбрать работника");
        }

        private void DropEmpBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmployeeDG.SelectedItem as users;
            if (selectedEmp != null)
            {
                App.DB.users.Remove(selectedEmp);
                App.DB.SaveChanges();
                MessageBox.Show("Успех");
                EmployeeDG.ItemsSource = App.DB.users.ToList();
            }
            else MessageBox.Show("Нужно выбрать работника");
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void AllEmpBT_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDG.ItemsSource = App.DB.users.ToList();
        }

        private void RoleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           EmployeeDG.ItemsSource = App.DB.users.Where(a => a.roleId == RoleCB.SelectedIndex+1).ToList();
        }
    }
}
