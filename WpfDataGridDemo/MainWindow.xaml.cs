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

namespace WpfDataGridDemo
{
    /// <summary>
    /// Achievement.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.dataGrid1.ItemsSource = CityInformation.GetInfo();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = System.Windows.Visibility.Visible;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = System.Windows.Visibility.Collapsed;
        }
        public T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.ShowDialog();
        }
    }
    public class CityInformation
    {
        public string AddrName { get; set; }
        public string CityName { get; set; }
        public string TelNum { get; set; }
        public double TotalSum { get; set; }
        public int IsDelete { get; set; }
        public static List<CityInformation> GetInfo()
        {
            return new List<CityInformation>()
            {
                new CityInformation() { AddrName="四川", CityName = "成都", TelNum="123", TotalSum = 1.23 },
                new CityInformation() { AddrName="广东", CityName = "广州", TelNum="234", TotalSum = 1.23,IsDelete=1 },
                new CityInformation() { AddrName="广西", CityName = "南宁", TelNum="0152", TotalSum = 1.23 },
                new CityInformation() { AddrName="贵州", CityName = "贵阳", TelNum="0123", TotalSum = 1.23 },
                new CityInformation() { AddrName="四川", CityName = "成都", TelNum="123", TotalSum = 10.23 }
            };
        }
    }
}
