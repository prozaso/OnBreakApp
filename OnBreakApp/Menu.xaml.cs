using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private ContratoCollection _contratoCollection = new ContratoCollection();
        private TipoEmpresaCollection _tipoEmpresaCollection = new TipoEmpresaCollection();
        private ActividadEmpresaCollection _actividadEmpresaCollection = new ActividadEmpresaCollection();
        private TipoEventoCollection _tipoEventoCollection = new TipoEventoCollection();
        private ModalidadServicioCollection _modalidadServicioCollection = new ModalidadServicioCollection();
        private Validadores _validadores = new Validadores();

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

        public ContratoCollection ContratoCollection
        {
            get
            {
                return _contratoCollection;
            }

            set
            {
                _contratoCollection = value;
            }
        }

        public TipoEmpresaCollection TipoEmpresaCollection
        {
            get
            {
                return _tipoEmpresaCollection;
            }
            set
            {
                _tipoEmpresaCollection = value;
            }
        }

        public ActividadEmpresaCollection ActividadEmpresaCollection
        {
            get
            {
                return _actividadEmpresaCollection;
            }
            set
            {
                _actividadEmpresaCollection = value;
            }
        }

        public TipoEventoCollection TipoEventoCollection
        {
            get
            {
                return _tipoEventoCollection;
            }
            set
            {
                _tipoEventoCollection = value;
            }
        }

        public ModalidadServicioCollection ModalidadServicioCollection
        {
            get
            {
                return _modalidadServicioCollection;
            }
            set
            {
                _modalidadServicioCollection = value;
            }
        }

        public Validadores Validadores
        {
            get
            {
                return _validadores;
            }
            set
            {
                _validadores = value;
            }
        }


        public Menu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SizeToContent = SizeToContent.WidthAndHeight;

            //Gestion Clientes
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = ClienteCollection.ReadAll();

            cboActividad.ItemsSource = null;
            cboActividad.ItemsSource = ActividadEmpresaCollection.ListaActividadEmpresa();
            cboTipo.ItemsSource = null;
            cboTipo.ItemsSource = TipoEmpresaCollection.ListaTipoEmpresa();


            //Lista Contratos
            dgListaContratos.ItemsSource = null;
            dgListaContratos.ItemsSource = ContratoCollection.ReadAll();


            //Gestion Contratos
            cboAsistentes.ItemsSource = null;
            cboAsistentes.ItemsSource = ContratoCollection.CantidadAsistentes();

            cboPersonalAdicional.ItemsSource = null;
            cboPersonalAdicional.ItemsSource = ContratoCollection.PersonalAdicional();

            dgListaContratos.ItemsSource = null;
            dgListaContratos.ItemsSource = ContratoCollection.ReadAll();

            cboTipoEvento.ItemsSource = null;
            cboTipoEvento.ItemsSource = TipoEventoCollection.ListaTipoEvento();

            cboTipoEventoNombre.ItemsSource = null;
            cboTipoEventoNombre.ItemsSource = ModalidadServicioCollection.ListaModalidadServicio();

        }


        //Menu
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


        //Gestion Clientes
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


        //Gestion Contratos
        private void BtnListaContratos_Click(object sender, RoutedEventArgs e)
        {
            expListaContratos.IsExpanded = true;
            expListaClientes.IsExpanded = false;
            expGestionClientes.IsExpanded = false;
            expGestionClientes.IsExpanded = false;
        }

        private void BtnLimpiarCampos_Click(object sender, RoutedEventArgs e)
        {
            txtNumeroDeContrato.Text = "";
            txtRutClienteContrato.Text = "";
            txtNombreClienteContrato.Text = "";
            txtValorEvento.Text = "";
            txtDireccionContrato.Text = "";
            txtObsercaciones.Text = "";

            cboTipoEvento.SelectedIndex = -1;
            cboAsistentes.SelectedIndex = -1;
            cboPersonalAdicional.SelectedIndex = -1;
            cboTipoEventoNombre.SelectedIndex = -1;

            fechaPicker.SelectedDate = null;
            horaInicioPicker.SelectedTime = null;
            horaTerminoPicker.SelectedTime = null;

        }

        private void BtnNumeroDeContrato_Click(object sender, RoutedEventArgs e)
        {

            String numero = txtNumeroDeContrato.Text;

            Contrato contrato = this.ContratoCollection.BuscarContratoPorNumero(numero);


            try
            {
                if (contrato == null)
                {
                    MessageBox.Show("Contrato no existe");
                }
                else
                {
                    if (contrato.Realizado)
                    {

                        //disable
                        txtNumeroDeContrato.IsEnabled = false;
                        txtRutClienteContrato.IsEnabled = false;
                        txtNombreClienteContrato.IsEnabled = false;
                        cboTipoEvento.IsEnabled = false;
                        cboTipoEventoNombre.IsEnabled = false;
                        cboAsistentes.IsEnabled = false;
                        cboPersonalAdicional.IsEnabled = false;
                        txtValorEvento.IsEnabled = false;
                        fechaPicker.IsEnabled = false;
                        horaInicioPicker.IsEnabled = false;
                        horaTerminoPicker.IsEnabled = false;
                        txtDireccion.IsEnabled = false;
                        txtObsercaciones.IsEnabled = false;
                        popGestion.IsEnabled = false;

                        //datos
                        txtNumeroDeContrato.Text = contrato.Numero;
                        txtRutClienteContrato.Text = contrato.RutCliente;
                        txtNombreClienteContrato.Text = this.ClienteCollection.BuscarClientePorRut(contrato.RutCliente).Nombre;
                        cboTipoEvento.SelectedValue = contrato.IdTipoEvento;
                        cboTipoEventoNombre.SelectedValue = contrato.IdModalidad;
                        fechaPicker.SelectedDate = contrato.FechaHoraInicio;
                        horaInicioPicker.SelectedTime = contrato.FechaHoraInicio;
                        horaTerminoPicker.SelectedTime = contrato.FechaHoraTermino;
                        cboAsistentes.SelectedValue = contrato.Asistentes;
                        cboPersonalAdicional.SelectedValue = contrato.PersonalAdicional;
                        txtValorEvento.Text = contrato.ValorTotalContrato.ToString();
                        txtObsercaciones.Text = contrato.Observaciones;
                    }
                    else
                    {
                        //datos
                        txtNumeroDeContrato.Text = contrato.Numero;
                        txtRutClienteContrato.Text = contrato.RutCliente;
                        txtNombreClienteContrato.Text = this.ClienteCollection.BuscarClientePorRut(contrato.RutCliente).Nombre;
                        cboTipoEvento.SelectedValue = contrato.IdTipoEvento;
                        cboTipoEventoNombre.SelectedValue = contrato.IdModalidad;
                        fechaPicker.SelectedDate = contrato.FechaHoraInicio;
                        horaInicioPicker.SelectedTime = contrato.FechaHoraInicio;
                        horaTerminoPicker.SelectedTime = contrato.FechaHoraTermino;
                        cboAsistentes.SelectedValue = contrato.Asistentes;
                        cboPersonalAdicional.SelectedValue = contrato.PersonalAdicional;
                        txtValorEvento.Text = contrato.ValorTotalContrato.ToString();
                        txtObsercaciones.Text = contrato.Observaciones;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando contrato");
            }
        }

        private void BtnRutCliente_Click(object sender, RoutedEventArgs e)
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
                    txtNombreClienteContrato.Text = cliente.Nombre;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando cliente");
            }
        }

        private void popCrearContrato_Click(object sender, RoutedEventArgs e)
        {

            int uf = 28000;
            int recargoAsistentes;
            double recargoPersonalAdicional;


            Contrato contrato = new Contrato();
            ModalidadServicio modalidadServicio = new ModalidadServicio();


            try
            {

                //if (txtRutClienteContrato is null)
                //{
                //    MessageBox.Show("Ingrese RUT del cliente");
                //}
                //else if (txtNombreClienteContrato is null)
                //{
                //    MessageBox.Show("Ingrese nombre del Cliente");
                //}
                //else
                //{
                string zero = "0";

                string year = DateTime.Now.ToString("yyyy");

                string month = DateTime.Now.ToString("MM");
                if (int.Parse(month) < 10)
                {
                    month = String.Concat(zero, month);
                }

                string day = DateTime.Now.ToString("dd");
                if (int.Parse(day) < 10)
                {
                    day = String.Concat(zero, day);
                }

                string hour = DateTime.Now.ToString("HH");
                if (int.Parse(hour) < 10)
                {
                    hour = String.Concat(zero, hour);
                }

                string min = DateTime.Now.ToString("mm");
                if (int.Parse(min) < 10)
                {
                    min = String.Concat(zero, min);
                }

                contrato.Numero = String.Concat(year, month, day, hour, min);
                contrato.Creacion = fechaPicker.SelectedDate.Value;

                contrato.Termino = horaTerminoPicker.SelectedTime.Value;

                contrato.RutCliente = txtRutClienteContrato.Text;

                contrato.IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());
                contrato.IdModalidad = cboTipoEventoNombre.SelectedValue.ToString();

                contrato.FechaHoraInicio = horaInicioPicker.SelectedTime.Value.ToLocalTime();
                contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value.ToLocalTime();

                contrato.Asistentes = int.Parse(cboAsistentes.SelectedValue.ToString());
                contrato.PersonalAdicional = int.Parse(cboPersonalAdicional.SelectedValue.ToString());

                contrato.Observaciones = txtObsercaciones.Text;
                contrato.Realizado = false;


                //obtenemos el valor de RECARGO POR ASISTENTES
                if (int.Parse(cboAsistentes.SelectedValue.ToString()) < 21)
                {
                    recargoAsistentes = (uf * 3);
                }
                else if (int.Parse(cboAsistentes.SelectedValue.ToString()) < 51)
                {
                    recargoAsistentes = (uf * 5);
                }
                else
                {
                    recargoAsistentes = /*Math.Truncate*/(((int.Parse(cboAsistentes.SelectedValue.ToString()) - 50) / 20) * (uf * 2)) + (uf * 5);
                }


                //obtenemos el valor de RECARGO POR PERSONAL ADICIONAL
                if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 3)
                {
                    recargoPersonalAdicional = (uf * 2);
                }
                else if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 4)
                {
                    recargoPersonalAdicional = (uf * 3);
                }
                else if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 5)
                {
                    recargoPersonalAdicional = (uf * 3.5);
                }
                else
                {
                    recargoPersonalAdicional = ((int.Parse(cboPersonalAdicional.SelectedValue.ToString()) - 4) * (uf / 2)) + (uf * 3.5);
                }


                //recibimos el tipo de evento, le sumamos los recargos y le asignamos el valor total al contrato y textbox
                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 10)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }

                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 20)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }

                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 30)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }


                if (this.ContratoCollection.CrearContrato(contrato))
                {
                    MessageBox.Show("Contrato creado correctamente");
                }
                else
                {
                    MessageBox.Show("Contrato no se pudo crear");
                }

                //}
            }
            catch (Exception)
            {

                MessageBox.Show("Error al crear contrato");
            }
        }

        private void popActualizarContrato_Click(object sender, RoutedEventArgs e)
        {

            int uf = 28000;
            int recargoAsistentes;
            double recargoPersonalAdicional;


            Contrato contrato = new Contrato();
            ModalidadServicio modalidadServicio = new ModalidadServicio();

            try
            {

                contrato.Creacion = fechaPicker.SelectedDate.Value;

                contrato.Termino = horaTerminoPicker.SelectedTime.Value;

                contrato.RutCliente = txtRutClienteContrato.Text;

                contrato.IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());
                contrato.IdModalidad = cboTipoEventoNombre.SelectedValue.ToString();

                contrato.FechaHoraInicio = horaInicioPicker.SelectedTime.Value.ToLocalTime();
                contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value.ToLocalTime();

                contrato.Asistentes = int.Parse(cboAsistentes.SelectedValue.ToString());
                contrato.PersonalAdicional = int.Parse(cboPersonalAdicional.SelectedValue.ToString());

                contrato.Observaciones = txtObsercaciones.Text;
                contrato.Realizado = false;


                //obtenemos el valor de RECARGO POR ASISTENTES
                if (int.Parse(cboAsistentes.SelectedValue.ToString()) < 21)
                {
                    recargoAsistentes = (uf * 3);
                }
                else if (int.Parse(cboAsistentes.SelectedValue.ToString()) < 51)
                {
                    recargoAsistentes = (uf * 5);
                }
                else
                {
                    recargoAsistentes = /*Math.Truncate*/(((int.Parse(cboAsistentes.SelectedValue.ToString()) - 50) / 20) * (uf * 2)) + (uf * 5);
                }


                //obtenemos el valor de RECARGO POR PERSONAL ADICIONAL
                if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 3)
                {
                    recargoPersonalAdicional = (uf * 2);
                }
                else if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 4)
                {
                    recargoPersonalAdicional = (uf * 3);
                }
                else if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 5)
                {
                    recargoPersonalAdicional = (uf * 3.5);
                }
                else
                {
                    recargoPersonalAdicional = ((int.Parse(cboPersonalAdicional.SelectedValue.ToString()) - 4) * (uf / 2)) + (uf * 3.5);
                }


                //recibimos el tipo de evento, le sumamos los recargos y le asignamos el valor total al contrato y textbox
                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 10)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }

                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 20)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }

                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 30)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }


                if (this.ContratoCollection.ModificarContrato(contrato))
                {
                    MessageBox.Show("Contrato actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("Contrato no se pudo actualizar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar contrato");
            }

        }

        private void popTerminarContrato_Click(object sender, RoutedEventArgs e)
        {
            string numero = txtNumeroDeContrato.Text;
            Contrato contrato = new Contrato();

            if (ContratoCollection.BuscarContratoPorNumero(numero) == null)
            {
                MessageBox.Show("Contrato no existe");
            }
            else
            {
                txtNumeroDeContrato.IsEnabled = false;
                txtRutClienteContrato.IsEnabled = false;
                txtNombreClienteContrato.IsEnabled = false;
                cboTipoEvento.IsEnabled = false;
                cboTipoEventoNombre.IsEnabled = false;
                cboAsistentes.IsEnabled = false;
                cboPersonalAdicional.IsEnabled = false;
                txtValorEvento.IsEnabled = false;
                fechaPicker.IsEnabled = false;
                horaInicioPicker.IsEnabled = false;
                horaTerminoPicker.IsEnabled = false;
                txtDireccion.IsEnabled = false;
                txtObsercaciones.IsEnabled = false;
                popGestion.IsEnabled = false;

                contrato.Realizado = true;
                MessageBox.Show("Contrato terminado correctamente");
            }
        }

        private void BtnValorEvento_Click(object sender, RoutedEventArgs e)
        {

            int uf = 28000;
            int recargoAsistentes;
            double recargoPersonalAdicional;


            Contrato contrato = new Contrato();
            ModalidadServicio modalidadServicio = new ModalidadServicio();


                //obtenemos el valor de RECARGO POR ASISTENTES
                if (int.Parse(cboAsistentes.SelectedValue.ToString()) < 21)
                {
                    recargoAsistentes = (uf * 3);
                }
                else if (int.Parse(cboAsistentes.SelectedValue.ToString()) < 51)
                {
                    recargoAsistentes = (uf * 5);
                }
                else
                {
                    recargoAsistentes = /*Math.Truncate*/(((int.Parse(cboAsistentes.SelectedValue.ToString()) - 50) / 20) * (uf * 2)) + (uf * 5);
                }


                //obtenemos el valor de RECARGO POR PERSONAL ADICIONAL
                if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 3)
                {
                    recargoPersonalAdicional = (uf * 2);
                }
                else if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 4)
                {
                    recargoPersonalAdicional = (uf * 3);
                }
                else if (int.Parse(cboPersonalAdicional.SelectedValue.ToString()) < 5)
                {
                    recargoPersonalAdicional = (uf * 3.5);
                }
                else
                {
                    recargoPersonalAdicional = ((int.Parse(cboPersonalAdicional.SelectedValue.ToString()) - 4) * (uf / 2)) + (uf * 3.5);
                }


                //recibimos el tipo de evento, le sumamos los recargos y le asignamos el valor total al contrato y textbox
                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 10)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }

                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 20)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }

                if (int.Parse(cboTipoEventoNombre.SelectedValue.ToString()) == 30)
                {
                    contrato.ValorTotalContrato = modalidadServicio.ValorBase * uf + recargoAsistentes + recargoPersonalAdicional;
                    txtValorEvento.Text = contrato.ValorTotalContrato.ToString("C0");
                }


        }

        private void CboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoEvento.SelectedValue.ToString() != null)
            {
                int modalidad = int.Parse(cboTipoEvento.SelectedValue.ToString());

                


                ModalidadServicioCollection.BuscarModalidad(modalidad);
            }
        }
    }
}