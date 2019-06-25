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
using Microsoft.VisualBasic;
using System.Windows.Interactivity;

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
        private Valorizador _valorizador = new Valorizador();

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

        public Valorizador Valorizador
        {
            get
            {
                return _valorizador;
            }
            set
            {
                _valorizador = value;
            }
        }


        public Menu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SizeToContent = SizeToContent.WidthAndHeight;


            //Gestion Clientes
            cboActividad.ItemsSource = null;
            cboActividad.ItemsSource = ActividadEmpresaCollection.ListaActividadEmpresa();

            cboTipo.ItemsSource = null;
            cboTipo.ItemsSource = TipoEmpresaCollection.ListaTipoEmpresa();

            //Lista Clientes
            CargarListaClientes();

            cboFiltrarActividad.ItemsSource = ActividadEmpresaCollection.ListaActividadEmpresa();
            cboFiltrarTipoCliente.ItemsSource = TipoEmpresaCollection.ListaTipoEmpresa();

            //Lista Contratos
            CargarListaContratos();

            cboTipoEvento.ItemsSource = null;
            cboTipoEvento.ItemsSource = TipoEventoCollection.ListaTipoEvento();

            cboFiltrarTipoEvento.ItemsSource = null;
            cboFiltrarTipoEvento.ItemsSource = TipoEventoCollection.ListaTipoEvento();


        }

        private void CargarListaContratos()
        {
            dgListaContratos.ItemsSource = null;
            dgListaContratos.ItemsSource = ContratoCollection.ReadAll();
        }

        private void CargarListaClientes()
        {
            //Lista Clientes
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = ClienteCollection.ReadAll();
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

            string rut = txtRut.Text.ToString().Replace(".", "");
            rut = rut.Replace(" ", "");


            Cliente cliente = this.ClienteCollection.BuscarClientePorRut(rut);

            try
            {
                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (cliente == null)
                {
                    MessageBox.Show("Cliente no existe");
                }
                else
                {
                    txtRut.Text = cliente.RutCliente;
                    txtRazon.Text = cliente.RazonSocial;
                    txtNombre.Text = cliente.NombreContacto;
                    txtMail.Text = cliente.MailContacto;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    cboActividad.SelectedValue = cliente.IdActividadEmpresa;
                    cboTipo.SelectedValue = cliente.IdTipoEmpresa;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando cliente");
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string rut = txtRut.Text.ToString().Replace(".", "");
                rut = rut.Replace(" ", "");

                string correo = txtMail.Text;

                Cliente cliente = new Cliente();

                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (ClienteCollection.BuscarClientePorRut(rut) != null)
                {
                    MessageBox.Show("Este cliente/Rut ya se encuentra en sistema");
                }
                else
                {

                    if (!Validadores.validarRut(rut))
                    {
                        MessageBox.Show("Rut incorrecto");
                        return;
                    }
                    else if (!Validadores.validarCorreo(correo))
                    {
                        MessageBox.Show("Correo incorrecto");
                        return;
                    }
                    else
                    {

                        cliente.RutCliente = rut.Replace(".", "");
                        cliente.RazonSocial = txtRazon.Text;
                        cliente.NombreContacto = txtNombre.Text;
                        cliente.MailContacto = txtMail.Text;
                        cliente.Direccion = txtDireccion.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.IdActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
                        cliente.IdTipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

                        if (ClienteCollection.AgregarCliente(cliente))
                        {
                            MessageBox.Show("Cliente agregado correctamente");
                            dgClientes.ItemsSource = ClienteCollection.ReadAll();
                        }
                        else
                        {
                            MessageBox.Show("Cliente no se pudo agregar");
                        }
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            try
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
            catch (Exception)
            {

                MessageBox.Show("Error limpiando campos");
            }

            
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
            string rut = txtRut.Text.ToString().Replace(".", "");
            rut = rut.Replace(" ", "");

            try
            {
                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (ClienteCollection.BuscarClientePorRut(rut) == null)
                {
                    MessageBox.Show("Cliente no existe");
                    return;
                }
                else if (txtRazon.Equals(cliente.RazonSocial) || txtNombre.Equals(cliente.NombreContacto) ||
                         txtMail.Equals(cliente.MailContacto) || txtDireccion.Equals(cliente.Direccion) ||
                         txtTelefono.Equals(cliente.Telefono) || int.Parse(cboActividad.SelectedValue.ToString()) == cliente.IdActividadEmpresa ||
                         int.Parse(cboTipo.SelectedValue.ToString()) == cliente.IdTipoEmpresa)
                {
                    MessageBox.Show("No hay cambios");
                    return;
                }
                else
                { 

                    cliente.RutCliente = rut;
                    cliente.RazonSocial = txtRazon.Text;
                    cliente.NombreContacto = txtNombre.Text;
                    cliente.MailContacto = txtMail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.IdActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
                    cliente.IdTipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

                    if (ClienteCollection.ModificarCliente(cliente))
                    {
                        MessageBox.Show("Cliente modificado correctamente");
                        dgClientes.ItemsSource = ClienteCollection.ReadAll();
                    }
                    else
                    {
                        MessageBox.Show("Este cliente no se pudo modificar");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al modificar");
            }
        }


        //Lista Clientes
        private void BtnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBuscarRutCliente.Text.Replace(" ", "");
            rut = rut.Replace(".", "");

            if (rut == "")
            {
                MessageBox.Show("Para buscar un cliente debe ingresar un RUT");
                CargarListaClientes();
            }
            else if (rut.Length < 9 || rut.Length > 12)
            {
                MessageBox.Show("Por favor ingrese un RUT valido");
            }
            else if (ClienteCollection.BuscarClientePorRut(rut) == null)
            {

                MessageBox.Show("Cliente no existe");
                CargarListaClientes();
                txtBuscarRutCliente.Text = "";
            }
            else
            {

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = ClienteCollection.ClienteFiltrarPorRut(rut);
                txtBuscarRutCliente.Text = "";
            }

        }

        private void BtnFiltrarTipo_Click(object sender, RoutedEventArgs e)
        {

            if (cboFiltrarTipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Para filtrar por tipo primero debe seleccionarlo");
                CargarListaClientes();
            }
            else if (ClienteCollection.BuscarClientePorTipo(int.Parse(cboFiltrarTipoCliente.SelectedValue.ToString())) == null)
            {

                MessageBox.Show("No existen Contratos con el tipo de Cliente seleccionado");
                CargarListaClientes();
                cboFiltrarTipoCliente.SelectedIndex = -1;
            }
            else
            {

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = ClienteCollection.ClienteFiltrarPorTipo(int.Parse(cboFiltrarTipoCliente.SelectedValue.ToString()));
                cboFiltrarTipoCliente.SelectedIndex = -1;
            }

        }

        private void BtnFiltrarActividad_Click(object sender, RoutedEventArgs e)
        {
            if (cboFiltrarActividad.SelectedIndex == -1)
            {
                MessageBox.Show("Para filtrar por actividad primero debe seleccionarla");
                CargarListaClientes();
            }
            else if (ClienteCollection.BuscarClientePorActividad(int.Parse(cboFiltrarActividad.SelectedValue.ToString())) == null)
            {

                MessageBox.Show("No existen Clientes con la actividad seleccionada");
                CargarListaClientes();
                cboFiltrarActividad.SelectedIndex = -1;
            }
            else
            {

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = ClienteCollection.ClienteFiltrarPorActividad(int.Parse(cboFiltrarActividad.SelectedValue.ToString()));
                cboFiltrarActividad.SelectedIndex = -1;
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

            try
            {
                txtNumeroDeContrato.Text = "";
                txtRutClienteContrato.Text = "";
                txtNombreClienteContrato.Text = "";
                txtValorEvento.Text = "";
                txtObservaciones.Text = "";
                txtPersonalBase.Text = "";

                cboTipoEvento.SelectedIndex = -1;
                txtAsistentes.Text = "";
                txtPersonalAdicional.Text = "";
                cboTipoEventoNombre.SelectedIndex = -1;

                fechaInicioPicker.SelectedDate = null;
                fechaTerminoPicker.SelectedDate = null;
                horaInicioPicker.SelectedTime = null;
                horaTerminoPicker.SelectedTime = null;


                txtNumeroDeContrato.IsEnabled = true;
                txtRutClienteContrato.IsEnabled = true;
                cboTipoEvento.IsEnabled = true;
                cboTipoEventoNombre.IsEnabled = true;
                txtAsistentes.IsEnabled = true;
                txtPersonalAdicional.IsEnabled = true;
                txtValorEvento.IsEnabled = true;
                fechaInicioPicker.IsEnabled = true;
                fechaTerminoPicker.IsEnabled = true;
                horaInicioPicker.IsEnabled = true;
                horaTerminoPicker.IsEnabled = true;
                txtObservaciones.IsEnabled = true;
                popGestion.IsEnabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Error limpiando campos");
            }

            


        }

        private void BtnNumeroDeContrato_Click(object sender, RoutedEventArgs e)
        {

            Contrato contrato = this.ContratoCollection.BuscarContratoPorNumero(txtNumeroDeContrato.Text.ToString());
            txtNumeroDeContrato.IsEnabled = false;
            txtRutClienteContrato.IsEnabled = false;

            try
            {
                if (contrato == null)
                {
                    MessageBox.Show("Contrato no existe");
                }
                else
                {
                    if (contrato.Realizado == false)
                    {

                        CamposVentanaContratoDisable();
                        CargarDatosVentanaContrato(contrato);

                    }
                    else if (fechaTerminoPicker.SelectedDate < DateTime.Today)
                    {
                        CamposVentanaContratoDisable();
                        CargarDatosVentanaContrato(contrato);
                    }
                    else
                    {

                        CargarDatosVentanaContrato(contrato);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando contrato");
            }
        }


        private void CargarDatosVentanaContrato(Contrato contrato)
        {
            txtNumeroDeContrato.Text = contrato.Numero;
            txtRutClienteContrato.Text = contrato.RutCliente;
            txtNombreClienteContrato.Text = ClienteCollection.BuscarClientePorRut(contrato.RutCliente).NombreContacto;
            cboTipoEvento.SelectedValue = contrato.IdTipoEvento;

            SelectionChangedTipoEvento();

            cboTipoEventoNombre.SelectedValue = contrato.IdModalidad;

            SelectionChangedModalidad();

            txtAsistentes.Text = contrato.Asistentes.ToString();
            txtPersonalAdicional.Text = contrato.PersonalAdicional.ToString();

            fechaInicioPicker.SelectedDate = contrato.Creacion;
            fechaTerminoPicker.SelectedDate = contrato.Termino;
            horaInicioPicker.SelectedTime = contrato.FechaHoraInicio;
            horaTerminoPicker.SelectedTime = contrato.FechaHoraTermino;

            txtObservaciones.Text = contrato.Observaciones;
        }
        private void CamposVentanaContratoDisable()
        {
            txtNumeroDeContrato.IsEnabled = false;
            txtRutClienteContrato.IsEnabled = false;
            txtNombreClienteContrato.IsEnabled = false;
            cboTipoEvento.IsEnabled = false;
            cboTipoEventoNombre.IsEnabled = false;
            txtAsistentes.IsEnabled = false;
            txtPersonalAdicional.IsEnabled = false;
            txtValorEvento.IsEnabled = false;
            fechaInicioPicker.IsEnabled = false;
            fechaTerminoPicker.IsEnabled = false;
            horaInicioPicker.IsEnabled = false;
            horaTerminoPicker.IsEnabled = false;
            txtObservaciones.IsEnabled = false;
            popGestion.IsEnabled = false;
        }


        private void BtnRutCliente_Click(object sender, RoutedEventArgs e)
        {

            String rut = txtRutClienteContrato.Text.Replace(".", "");
            rut = rut.Replace(" ", "");

            Cliente cliente = this.ClienteCollection.BuscarClientePorRut(rut);

            try
            {
                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (cliente == null)
                {
                    MessageBox.Show("Cliente no existe");
                }
                else
                {
                    txtNombreClienteContrato.Text = cliente.NombreContacto;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando cliente");
            }
        }

        private void popCrearContrato_Click(object sender, RoutedEventArgs e)
        {


            try
            {

                Contrato contrato = new Contrato();
                ModalidadServicio modalidadServicio = new ModalidadServicio();

                contrato.Numero = DateTime.Now.ToString("ddMMyyyyHHmm");


                //guardamos fecha de creacion de contrato con formato dia/mes/año
                string fechaCreacion = DateTime.Now.ToString("dd/MM/yyyy");
                contrato.Creacion = DateTime.Parse(fechaCreacion);

                //guardamos la fecha de creacion en fecha termino para cuando el usuario termne el contrato esta fecha sea reemplazada
                string fechaTerminoUsuario = DateTime.Now.ToString("dd/MM/yyyy");
                contrato.Termino = DateTime.Parse(fechaTerminoUsuario);

                //Guardamos rut sin puntos ni espacios
                string rut = txtRutClienteContrato.Text.Replace(".", "");
                rut = rut.Replace(" ", "");
                contrato.RutCliente = rut;

                contrato.IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());
                contrato.IdModalidad = cboTipoEventoNombre.SelectedValue.ToString().Trim();

                //guardamos la fecha y hora de inicio del evento
                string fechaInicio = fechaInicioPicker.SelectedDate.Value.ToString("dd/MM/yyyy");
                string horaInicio = horaInicioPicker.SelectedTime.Value.ToString("HH:mm");
                contrato.FechaHoraInicio = DateTime.Parse(fechaInicio + " " + horaInicio);

                //guardamos la fecha y hora del termino del evento
                string fechaTermino = fechaTerminoPicker.SelectedDate.Value.ToString("dd/MM/yyyy");
                contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value;

                contrato.Asistentes = int.Parse(txtAsistentes.Text.ToString());
                contrato.PersonalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());

                contrato.Observaciones = txtObservaciones.Text.ToString();
                contrato.Realizado = true;

                //calculamos valor del contrato para guardarlo
                string e_Calculo = cboTipoEventoNombre.SelectedValue.ToString();
                int cantidadAsistentes = int.Parse(txtAsistentes.Text.ToString());
                int personalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());
                contrato.ValorTotalContrato = Valorizador.CalculoEvento(e_Calculo, cantidadAsistentes, personalAdicional);

                if (this.ContratoCollection.CrearContrato(contrato))
                {
                    txtNumeroDeContrato.Text = DateTime.Now.ToString("ddMMyyyyHHmm");
                    MessageBox.Show("Contrato creado correctamente");
                    dgListaContratos.ItemsSource = null;
                    dgListaContratos.ItemsSource = ContratoCollection.ReadAll();
                }
                else
                {
                    MessageBox.Show("Contrato no se pudo crear");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error al crear contrato");
            }
        }

        private void popActualizarContrato_Click(object sender, RoutedEventArgs e)
        {

            Contrato contrato = new Contrato();
            

            try
            {
                if (ContratoCollection.BuscarContratoPorNumero(txtNumeroDeContrato.Text.ToString()) == null)
                {
                    MessageBox.Show("Numero de contrato no existe");
                    return;
                }
                else
                {
                    contrato.Creacion = fechaInicioPicker.SelectedDate.Value;

                    contrato.Termino = fechaTerminoPicker.SelectedDate.Value;


                    contrato.Numero = txtNumeroDeContrato.Text.ToString();



                    contrato.IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());

                        //SelectionChangedTipoEvento();

                    contrato.IdModalidad = cboTipoEventoNombre.SelectedValue.ToString();

                        //SelectionChangedModalidad();

                    contrato.FechaHoraInicio = horaInicioPicker.SelectedTime.Value;
                    contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value;

                    contrato.Asistentes = int.Parse(txtAsistentes.Text.ToString());
                    contrato.PersonalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());

                    contrato.Observaciones = txtObservaciones.Text.ToString();
                    //contrato.Realizado = false;

                    string e_Calculo = cboTipoEventoNombre.SelectedValue.ToString();
                    int cantidadAsistentes = int.Parse(txtAsistentes.Text.ToString());
                    int personalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());
                    contrato.ValorTotalContrato = Valorizador.CalculoEvento(e_Calculo, cantidadAsistentes, personalAdicional);


                    if (ContratoCollection.ModificarContrato(contrato))
                    {
                        MessageBox.Show("Contrato actualizado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Contrato no se pudo actualizar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar contrato");
            }

        }

        private void popTerminarContrato_Click(object sender, RoutedEventArgs e)
        {
            string numero = txtNumeroDeContrato.Text.ToString();
            Contrato contrato = new Contrato();

            try
            {
                if (ContratoCollection.BuscarContratoPorNumero(numero) == null)
                {
                    MessageBox.Show("Contrato no existe");
                }
                else
                {

                    contrato.Numero = numero;
                    contrato.Realizado = false;

                    if (ContratoCollection.TerminarContrato(contrato))
                    {
                        
                        MessageBox.Show("Contrato terminado correctamente");
                        dgListaContratos.ItemsSource = null;
                        dgListaContratos.ItemsSource = ContratoCollection.ReadAll();
                    }
                    else
                    {
                        MessageBox.Show("Error Terminando contrato");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Terminando contrato");
            }

            
        }

        private void BtnValorEvento_Click(object sender, RoutedEventArgs e)
        {

            Contrato contrato = new Contrato();

            try
            {
                string e_Calculo = cboTipoEventoNombre.SelectedValue.ToString();
                int cantidadAsistentes = int.Parse(txtAsistentes.Text.ToString());
                int personalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());

                txtValorEvento.Text = Valorizador.CalculoEvento(e_Calculo, cantidadAsistentes, personalAdicional).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Error calculando valor");
            }          

        }


        private void SelectionChangedTipoEvento()
        {
            if (cboTipoEvento.SelectedValue == null)
            {
                cboTipoEventoNombre.ItemsSource = null;
            }
            else
            {
                int evento = int.Parse(cboTipoEvento.SelectedValue.ToString());
                cboTipoEventoNombre.ItemsSource = null;
                cboTipoEventoNombre.ItemsSource = ModalidadServicioCollection.BuscarModalidad(evento);
            }
        }
        private void SelectionChangedModalidad()
        {
            if (cboTipoEventoNombre.SelectedValue == null)
            {

                txtAsistentes.Text = null;
                txtPersonalAdicional.Text = null;
            }
            else
            {

                string evento = cboTipoEventoNombre.SelectedValue.ToString();

                txtPersonalBase.Text = ModalidadServicioCollection.personalBase(evento).ToString();

            }
        }


        private void CboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedTipoEvento();

        }

        private void CboTipoEventoNombre_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedModalidad();
        }

        
        //Lista Contratos
        private void BtnFiltrarNumero_Click(object sender, RoutedEventArgs e)
        {

            string numero = txtBuscarNumeroContrato.Text.Replace(" ", "");

            if (numero == "")
            {
                MessageBox.Show("Porfavor ingrese numero de contrato");
                CargarListaContratos();
            }
            else if (numero.Length < 12)
            {
                MessageBox.Show("Por favor ingrese un numero de contrato valido");
                CargarListaContratos();
            }
            else if (ContratoCollection.BuscarContratoPorNumero(numero) == null)
            {

                MessageBox.Show("No existe Contrato con numero ingresado");
                CargarListaContratos();

            }
            else
            {

                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarFiltroNumero(numero);
                txtBuscarNumeroContrato.Text = "";
            }
            
        }

        private void BtnFiltrarRutContrato_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBuscarRutContrato.Text.Replace(" ", "");
            rut = txtBuscarRutContrato.Text.Replace(".", "");

            if (rut.Length < 9)
            {
                MessageBox.Show("Por favor ingrese un RUT valido");
                CargarListaContratos();
            }
            else if (rut == "")
            {
                MessageBox.Show("Por favor ingrese un RUT");
                CargarListaContratos();
            }
            else if (ContratoCollection.BuscarContratoPorRut(rut) != null)
            {
                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarFiltroRutCliente(rut);
                txtBuscarRutContrato.Text = "";
            }
            else
            {
                MessageBox.Show("No existen contratos asociados a este RUT");
                CargarListaContratos();
            }

        }

        private void BtnFiltrarTipoEvento_Click(object sender, RoutedEventArgs e)
        {


            if (cboFiltrarTipoEvento.SelectedIndex == -1)
            {
                MessageBox.Show("Para filtrar por tipo primero debe seleccionarlo");
                CargarListaContratos();
            }
            else if (ContratoCollection.BuscarContratoPorTipo(int.Parse(cboFiltrarTipoEvento.SelectedValue.ToString())) == null)
            {

                MessageBox.Show("No existen Contratos con el tipo seleccionado");
                CargarListaContratos();
                cboFiltrarTipoEvento.SelectedIndex = -1;
            }
            else
            {

                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarFiltroTipoEvento(int.Parse(cboFiltrarTipoEvento.SelectedValue.ToString()));
                cboFiltrarTipoEvento.SelectedIndex = -1;
            }
        }

    }
}