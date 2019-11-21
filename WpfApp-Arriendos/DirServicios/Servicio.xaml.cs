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
using System.Data;
using Negocio.Clases;
using System.Text.RegularExpressions;

namespace WpfApp_Arriendos.DirServicios
{
    public partial class Servicio : Window
    {
        //Atributos de la vista.
        ServicioExtraCollection sc;
        TourCollection tc;
        TransporteCollection trc;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public Servicio()
        {
            InitializeComponent();
            datosServicio();
            datosTour();
            datosTransporte();
        }

        #region Navbar

        //Boton que dirige a la vista de Inicio.
        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        //Boton que dirige a la vista Funcionario.
        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.Show();
            this.Close();
        }

        //Boton que dirige a la vista Servicios.
        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
            this.UpdateLayout();
            datosServicio();
            datosTour();
            datosTransporte();
        }

        //Boton que dirige a la vista Departamento.
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            DirDepartamentos.GestorDepartamentos depa = new DirDepartamentos.GestorDepartamentos();
            depa.Show();
            this.Close();
        }
        #endregion Navbar

        #region Navegación Servicios

        //Boton que realizar la accion redireccionar a NuevoServicio para registrar datos segun el Servicio extra.
        private void btnRegistrarServicio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirServicios.NuevoServicioExtra ns = new DirServicios.NuevoServicioExtra();
                ns.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton que realizar la accion redireccionar a NuevoTour para registrar datos segun el Tour.
        private void btnRegistrarTour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirServicios.NuevoTour nt = new DirServicios.NuevoTour();
                nt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton que realizar la accion redireccionar a NuevoTransporte para registrar datos segun el Transporte.
        private void btnRegistrarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirServicios.NuevoTransporte ntr = new DirServicios.NuevoTransporte();
                ntr.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion Navegación Servicios

        #region Servicios

        //Boton para realizar la accion de actualizar datos de Servicio extra.
        private void btnActualizarServicio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdServicio.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo de las tablas.");
                }
                else if (Regex.IsMatch(txtIdServicio.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Código del servicio debe ser numérico.");
                }
                else if (string.IsNullOrEmpty(txt1.Text) || txt1.Text.Length < 5 && txt1.Text.Length > 200)
                {
                    MessageBox.Show("Descripción no debe estar vacío y tiene que estar entre 5 a 200 carácteres.");
                }
                else if (Regex.IsMatch(txt2.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Costo debe ser numérico.");

                }
                else if (string.IsNullOrEmpty(txt2.Text) || int.Parse(txt2.Text) <= 0 && int.Parse(txt2.Text) >= 999999)
                {
                    MessageBox.Show("Costo no debe estar vacío y debe ser mayor a 0 o menor a 999.999");

                }
                else
                {
                    sc = new ServicioExtraCollection();

                    sc.ActualizaServicioExtraC(int.Parse(txtIdServicio.Text), txt1.Text, int.Parse(txt2.Text));

                    lblmensaje.Content = "Actualización correcta!";
                    Limpiar();
                    datosServicio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de eliminar un Servicio extra.
        private void btnEliminarServicio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdServicio.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo de las tablas.");
                }
                else
                {
                    sc = new ServicioExtraCollection();

                    sc.EliminaServicioExtraC(int.Parse(txtIdServicio.Text));

                    txtIdServicio.Text = string.Empty;
                    txt1.Text = string.Empty;
                    txt2.Text = string.Empty;
                    lblmensaje.Content = "Eliminado!";
                    Limpiar();
                    datosServicio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de actualizar datos de Tour.
        private void btnActualizarTour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdServicio.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo de las tablas.");
                }
                else if (string.IsNullOrEmpty(txt1.Text) || txt1.Text.Length < 5 && txt1.Text.Length > 200)
                {
                    MessageBox.Show("Descripción no debe estar vacío y tiene que estar entre 5 a 200 carácteres.");
                }
                else
                {
                    tc = new TourCollection();

                    tc.ActualizaTourC(int.Parse(txtIdServicio.Text), txt1.Text);

                    lblmensaje.Content = "Actualización correcta!";
                    Limpiar();
                    datosTour();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de eliminar un Tour.
        private void btnEliminarTour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdServicio.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo de las tablas.");
                }
                else
                {
                    tc = new TourCollection();

                    tc.EliminaTourC(int.Parse(txtIdServicio.Text));

                    txtIdServicio.Text = string.Empty;
                    txt1.Text = string.Empty;
                    txt2.Text = string.Empty;
                    lblmensaje.Content = "Eliminado!";
                    Limpiar();
                    datosTour();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de eliminar un Transporte.
        private void btnEliminarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdServicio.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo de las tablas.");
                }
                else
                {
                    trc = new TransporteCollection();

                    trc.EliminaTransporteC(int.Parse(txtIdServicio.Text));

                    txtIdServicio.Text = string.Empty;
                    txt1.Text = string.Empty;
                    txt2.Text = string.Empty;
                    lblmensaje.Content = "Eliminado!";
                    Limpiar();
                    datosTransporte();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de actualizar datos de Transporte.
        private void btnActualizarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdServicio.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo de las tablas.");
                }
                else if (string.IsNullOrEmpty(txt1.Text) || txt1.Text.Length < 3 && txt1.Text.Length > 100)
                {
                    MessageBox.Show("Nombre no debe estar vacío y tiene que estar entre 3 a 100 carácteres.");
                }
                else if (string.IsNullOrEmpty(txt2.Text) || txt2.Text.Length >= 9)
                {
                    MessageBox.Show("El campo patente no debe estar vacío y ser mayor a 8 carácteres.");
                }
                else if (!Regex.IsMatch(txt2.Text, "^[a-zA-Z]{2}[-][a-zA-Z]{2}[-][0-9]{2}$"))
                {
                    MessageBox.Show("El campo patente debe tener formato AA-AA-99.");
                }
                else
                {
                    trc = new TransporteCollection();

                    trc.ActualizaTransporteC(int.Parse(txtIdServicio.Text), txt1.Text, txt2.Text);

                    lblmensaje.Content = "Actualización correcta!";
                    Limpiar();
                    datosTransporte();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Tabla que muestra los datos de Servicios extra en la vista.
        private void dtgServicios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;

            DataRowView seleccionado = gd.SelectedItem as DataRowView;
            if (seleccionado != null)
            {
                txtIdServicio.Text = seleccionado.Row[0].ToString();
                txt1.Text = seleccionado.Row[1].ToString();
                txt2.IsEnabled = true;
                txt2.Text = seleccionado.Row[2].ToString();


                btnActualizarServicio.Visibility = Visibility.Visible;
                btnEliminarServicio.Visibility = Visibility.Visible;

                btnActualizarTour.Visibility = Visibility.Hidden;
                btnActualizarTransporte.Visibility = Visibility.Hidden;
                btnEliminarTour.Visibility = Visibility.Hidden;
                btnEliminarTransporte.Visibility = Visibility.Hidden;
            }
        }

        //Tabla que muestra los datos de Tour en la vista.
        private void dtgTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;

            DataRowView seleccionado = gd.SelectedItem as DataRowView;
            if (seleccionado != null)
            {
                txtIdServicio.Text = seleccionado.Row[0].ToString();
                txt1.Text = seleccionado.Row[1].ToString();
                txt2.IsEnabled=false;

                btnActualizarTour.Visibility = Visibility.Visible;
                btnEliminarTour.Visibility = Visibility.Visible;

                btnActualizarServicio.Visibility = Visibility.Hidden;
                btnActualizarTransporte.Visibility = Visibility.Hidden;
                btnEliminarServicio.Visibility = Visibility.Hidden;
                btnEliminarTransporte.Visibility = Visibility.Hidden;
            }
        }

        //Tabla que muestra los datos de Transporte en la vista.
        private void dtgTransporte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;

            DataRowView seleccionado = gd.SelectedItem as DataRowView;
            if (seleccionado != null)
            {
                txtIdServicio.Text = seleccionado.Row[0].ToString();
                txt1.Text = seleccionado.Row[1].ToString();
                txt2.IsEnabled = true;
                txt2.Text = seleccionado.Row[2].ToString();

                btnActualizarTransporte.Visibility = Visibility.Visible;
                btnEliminarTransporte.Visibility=Visibility.Visible;

                btnActualizarTour.Visibility = Visibility.Hidden;
                btnActualizarServicio.Visibility = Visibility.Hidden;
                btnEliminarTour.Visibility = Visibility.Hidden;
                btnEliminarServicio.Visibility = Visibility.Hidden;
            }
        }
        #endregion Servicios

        #region Métodos Custom

        //Metodo para mostrar los datos de Servicio extra.
        private void datosServicio()
        {
            sc = new ServicioExtraCollection();

            dtgServicios.ItemsSource = sc.ListaServicioExtraC().DefaultView;

            dtgServicios.Items.Refresh();

        }

        //Metodo para mostrar los datos de Tour.
        private void datosTour()
        {
            tc = new TourCollection();

            dtgTour.ItemsSource = tc.ListaTourC().DefaultView;

            dtgTour.Items.Refresh();

        }

        //Metodo para mostrar los datos de Transporte.
        private void datosTransporte()
        {
            TransporteCollection transc = new TransporteCollection();

            dtgTransporte.ItemsSource = transc.ListaTransporteC().DefaultView;

            dtgTransporte.Items.Refresh();

        }

        //Metodo para limpiar campos de textos.
        private void Limpiar()
        {
            txtIdServicio.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
        }
        #endregion Métodos Custom
    }
}
