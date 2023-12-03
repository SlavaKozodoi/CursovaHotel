using CursovaFinal.View;
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

namespace CursovaFinal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private 
        UserManager userManager = new UserManager();
        string content = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }
        string EMAIL = "Special code";



        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailLogin.Text;
            string password = PasswordLogin.Password;

            if (userManager.ValidateUser(email, password))
            {
                MainWindowView windowView= new MainWindowView();
                windowView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не вірна пошта чи пароль");

            }
        }
        private void GotTextBox_Delete(object sender, RoutedEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (textBox.Text == EMAIL)
            {
                content = textBox.Text;
                textBox.Text = string.Empty;
            };
            textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));




        }

        private void Tetxbox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = content;
                content = string.Empty;
            }
            textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xA1, 0xCE, 0xDE));

        }
    }
}
