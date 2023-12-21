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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lekarstva lecObj = new Lekarstva()
                {
                    Name = txtName.Text,
                    Price = Convert.ToInt32(txtPrice.Text),
                    Manufacturer= txtManufacturer.Text,

                };
                DbConnect.entObj.Lekarstva.Add(lecObj);
                DbConnect.entObj.SaveChanges();

                MessageBox.Show("Лекарство добавлен!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                FrameApp.frmObj.Navigate(new Spisok());
                    }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                    "Сбой работы приложения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
