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
    /// Логика взаимодействия для SpisokUser.xaml
    /// </summary>
    public partial class SpisokUser : Page
    {
        private List<Lekarstva> allItems;
        public SpisokUser()
        {
            InitializeComponent();
            allItems = DbConnect.entObj.Lekarstva.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            SearchResultsListView.ItemsSource = DbConnect.entObj.Lekarstva.ToList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SearchResultsListView.ItemsSource = DbConnect.entObj.Lekarstva.Where(x => x.Name.Contains(SearchTextBox.Text)).Take(15).ToList();
                ResultTxb.Text = SearchResultsListView.Items.Count + "/" + DbConnect.entObj.Lekarstva.Where(x => x.Name.Contains(SearchTextBox.Text)).Count().ToString();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private void SearchCriteriaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchCriteriaComboBox.SelectedIndex == 0)
            {
                List<Lekarstva> sortMaterials = allItems.OrderBy(x => x.Name).ToList();
                SearchResultsListView.ItemsSource = sortMaterials;
            }
            else if (SearchCriteriaComboBox.SelectedIndex == 1)
            {
                List<Lekarstva> sortMaterials = allItems.OrderByDescending(x => x.Name).ToList();
                SearchResultsListView.ItemsSource = sortMaterials;
            }
        }

        private void SearchResultsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }


