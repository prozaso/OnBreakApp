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

        private ClienteCollection _clienteCollection = new ClienteCollection();

        public ClienteCollection ClienteCollection
        {
            get
            {
                return _clienteCollection;
            }

            set
            {
                _clienteCollection = value;
            }
        }

        public Menu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SizeToContent = SizeToContent.WidthAndHeight;

            ClienteCollection clienteCollection = new ClienteCollection();

            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = clienteCollection.ReadAll();

            cboActividad.ItemsSource = null;
            cboActividad.ItemsSource = clienteCollection.ListaActividadEmpresa();
            cboTipo.ItemsSource = null;
            cboTipo.ItemsSource = clienteCollection.ListaTipoEmpresa();
            
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

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            String rut = txtRut.Text;

            Cliente cliente = this.ClienteCollection.BuscarClientePorRut(rut);

            try
            {
                if (cliente == null)
                {
                    MessageBox.Show("Cliente no existe");
                }
                else
                {
                    txtRut.Text = cliente.Rut;
                    txtRazon.Text = cliente.RazonSocial;
                    txtNombre.Text = cliente.Nombre;
                    txtMail.Text = cliente.Mail;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    cboActividad.SelectedValue = cliente.ActividadEmpresa;
                    cboTipo.SelectedValue = cliente.TipoEmpresa;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando cliente");
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Cliente cliente = new Cliente();
            string rut = txtRut.Text;
            try
            {
                cliente.Rut = rut;
                cliente.RazonSocial = txtRazon.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Mail = txtMail.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.ActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
                cliente.TipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

                if (this.ClienteCollection.AgregarCliente(cliente))
                {
                    MessageBox.Show("Cliente agregado correctamente");
                }
                else
                {
                    MessageBox.Show("Este cliente ya existe");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = "";
            txtRazon.Text = "";
            txtNombre.Text = "";
            txtMail.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cboActividad.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
        }

        private void BtnListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            expListaClientes.IsExpanded = true;
            expGestionClientes.IsExpanded = false;
            expListaContratos.IsExpanded = false;
            expGestionClientes.IsExpanded = false;
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            string rut = txtRut.Text;
            try
            {
                //cliente.Rut = rut;
                cliente.RazonSocial = txtRazon.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Mail = txtMail.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.ActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
                cliente.TipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

                if (this.ClienteCollection.ModificarCliente(cliente))
                {
                    MessageBox.Show("Cliente modificado correctamente");
                }
                else
                {
                    MessageBox.Show("Este cliente no se pudo modificar");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al modificar");
            }
        }
    }
    
}