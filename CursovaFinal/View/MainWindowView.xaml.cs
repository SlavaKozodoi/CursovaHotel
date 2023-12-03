using Cursova123.View;
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

namespace CursovaFinal.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        


        public MainWindowView()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            DataContext = new CheckInViewModel();
            DataContext = new MainViewModel();



        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені,що хочете закрити застосунок?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckIn window = new CheckIn();
            window.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CheckOut window = new CheckOut();
            window.Show();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InfoClients window = new InfoClients();
            window.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReservedRoms window = new ReservedRoms();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RoomsInfoView window = new RoomsInfoView();
            window.Show();

        }
    }
}
