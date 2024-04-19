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
    /// Логика взаимодействия для EditEmpP.xaml
    /// </summary>
    public partial class EditEmpP : Page
    {
        users context;
        public EditEmpP(users editedUser)
        {
            InitializeComponent();
            RoleCB.ItemsSource = App.DB.role.ToList();
            context = editedUser;
            DataContext = context;
        }

        private void EditEmpBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0)
                    App.DB.users.Add(context);
                App.DB.SaveChanges();
                MessageBox.Show("Успех");
                NavigationService.Navigate(new HrManagerP());
            }
            catch
            {
                MessageBox.Show("Ошибка");
                return;
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HrManagerP());

        }
    }
}
