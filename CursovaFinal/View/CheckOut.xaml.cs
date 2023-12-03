using Cursova123.ViewModels;
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

namespace Cursova123.View
{
    /// <summary>
    /// Логика взаимодействия для CheckOut.xaml
    /// </summary>
    public partial class CheckOut : Window
    {
        public CheckOut()
        {
            InitializeComponent();
            DataContext = new CheckOutViewModel();
        }
    }
}
