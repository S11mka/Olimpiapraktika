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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Page
    {
        public MainWindow1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var userObj = DbConnect.entObj.User.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPassword.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден!",
                               "Уведомление",
                               MessageBoxButton.OK,
                              MessageBoxImage.Information);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, " + userObj.Login + "!",
                               "Уведомление",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new Spisok());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте,  " + userObj.Login + "!",
                               "Уведомление",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new SpisokUser());
                            break;
                        default:
                            MessageBox.Show("Такой пользователь не найден!",
                               "Уведомление",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе предложения: " + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }   
    }
    
}