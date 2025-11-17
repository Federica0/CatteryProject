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

namespace Wpf
{
    /// <summary>
    /// Logica di interazione per AddAdoption.xaml
    /// </summary>
    public partial class AddAdoption : Window
    {
        public AddAdoption()
        {
            InitializeComponent();
        }

        private void Menu3_Click(object sender, RoutedEventArgs e)
        {
            var a = new MainWindow();
            a.Show(); this.Close();
        }

       
    }
}
