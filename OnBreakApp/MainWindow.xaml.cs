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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace OnBreakApp
{
    public partial class MainWindow
    {
        public static MainWindow ventanaMain;

        public static MainWindow getInstance()
        {
            if (ventanaMain == null)
            {
                ventanaMain = new MainWindow();
            }
            return ventanaMain;
        }

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.OnClosed(e);
            Application.Current.Shutdown();
        }


    }
}
