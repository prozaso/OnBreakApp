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
using OnBreakLibrary;

namespace OnBreakApp
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
     
        

    public partial class Menu
    {
        public static Menu ventanaMenu;

        public static Menu getInstance()
        {
            if (ventanaMenu == null)
            {
                ventanaMenu = new Menu();
            }
            return ventanaMenu;
        }

        public Menu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SizeToContent = SizeToContent.WidthAndHeight;

            ClienteCollection clienteCollection = new ClienteCollection();

            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = clienteCollection.ReadAll();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaMenu = null;
            MainWindow ventanaMain = new MainWindow();
            ventanaMain.Show();
        }

        private void MetroWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void expanderGestionClientes(object sender, RoutedEventArgs args)
        {
            if (expGestionClientes.IsExpanded)
            {
                expListaClientes.IsExpanded = false;
                expGestionContratos.IsExpanded = false;
                expListaContratos.IsExpanded = false;
            }
        }

        private void expanderListaClientes(object sender, RoutedEventArgs args)
        {
            if (expListaClientes.IsExpanded)
            {
                expGestionClientes.IsExpanded = false;
                expGestionContratos.IsExpanded = false;
                expListaContratos.IsExpanded = false;
            }
        }

        private void expanderGestionContratos(object sender, RoutedEventArgs args)
        {
            if (expGestionContratos.IsExpanded)
            {
                expListaClientes.IsExpanded = false;
                expGestionClientes.IsExpanded = false;
                expListaContratos.IsExpanded = false;
            }
        }

        private void expanderListaContratos(object sender, RoutedEventArgs args)
        {
            if (expListaContratos.IsExpanded)
            {
                expGestionClientes.IsExpanded = false;
                expListaClientes.IsExpanded = false;
                expGestionContratos.IsExpanded = false;
            }
        }

    }
}