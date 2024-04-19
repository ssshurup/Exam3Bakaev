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
    /// Логика взаимодействия для CallCenterP.xaml
    /// </summary>
    public partial class CallCenterP : Page
    {
        public CallCenterP()
        {
            InitializeComponent();
            ZayavkiDG.ItemsSource = App.DB.zayavka.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CallCenterP());
        }
    }
}
