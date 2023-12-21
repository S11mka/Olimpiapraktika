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
    /// Логика взаимодействия для Spisok.xaml
    /// </summary>
    public partial class Spisok : Page
    {
        public Spisok()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Add());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var AptForRemoving = dgMedicines.SelectedItems.Cast<Lekarstva>().ToList();
            try
            {
                DbConnect.entObj.Lekarstva.RemoveRange(AptForRemoving);
                DbConnect.entObj.SaveChanges();
                MessageBox.Show("Данные удалены");

                dgMedicines.ItemsSource = DbConnect.entObj.Lekarstva.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Подтвердите удаление " + ex.Message.ToString(),
                    "Уведомления",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                dgMedicines.ItemsSource = DbConnect.entObj.Lekarstva.ToList();
        }
    }
}
