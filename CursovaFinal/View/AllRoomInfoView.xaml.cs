using Cursova123.Models;
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
    /// Логика взаимодействия для AllRoomInfoView.xaml
    /// </summary>
    public partial class AllRoomInfoView : Window
    {
        public AllRoomInfoView(Room room)
        {
            InitializeComponent();

            // Присвоение контекста данных окну
            DataContext = new RoomInfoViewModel(room);

            switch (room.RoomClass)
            {
                case "Люкс":
                    Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/View/LuxuryBackground.jpg")));
                    break;

                case "Полулюкс":
                    Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/View/PoluLuxuryBackground.jpg")));
                    break;

                case "Стандарт":
                    Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/View/Standart.png")));
                    break;

                case "Економ":
                    Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/View/Econom.jpg")));
                    break;
                default:
                    
                    break;
            }
        }
       

    }
}
