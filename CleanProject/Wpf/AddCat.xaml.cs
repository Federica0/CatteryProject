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
    /// Logica di interazione per AddCat.xaml
    /// </summary>
    public partial class AddCat : Window
    {
        public AddCat()
        {
            InitializeComponent();
        }

        private void Menu4_Click(object sender, RoutedEventArgs e)
        {
            var a = new MainWindow();
            a.Show(); this.Close();
        }

        
    }
}
