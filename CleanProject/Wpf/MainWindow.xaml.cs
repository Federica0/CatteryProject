using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_AddCatWindows(object sender, RoutedEventArgs e)
        {
            var a = new AddCat();
            a.Show(); this.Close();
        }
        private void Btn_ManagementCatWindows(object sender, RoutedEventArgs e)
        {
            var a = new ManagementCat();
            a.Show(); this.Close();
        }
        private void Btn_AddAdoptionWindows(object sender, RoutedEventArgs e)
        {
            var a = new AddAdoption();
            a.Show(); this.Close();
        }
        private void Btn_ManagementAdoptionWindows(object sender, RoutedEventArgs e)
        {
            var a = new MangementAdoption();
            a.Show(); this.Close();
        }
        private void Btn_AddUserWindows(object sender, RoutedEventArgs e)
        {
            var a = new AddUser();
            a.Show(); this.Close();
        }
        private void Btn_ManagementUserWindows(object sender, RoutedEventArgs e)
        {
            var a = new ManagemetUser();
            a.Show(); this.Close();
        }
    }
}