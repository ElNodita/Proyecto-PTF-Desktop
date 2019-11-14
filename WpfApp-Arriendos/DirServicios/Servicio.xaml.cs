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
    /// <summary>
    /// Lógica de interacción para Servicio.xaml
    /// </summary>
    public partial class Servicio : Window
    {
        ServicioExtraCollection sc;
        TourCollection tc;
        TransporteCollection trc;
        public Servicio()
        {
            InitializeComponent();
            datosServicio();
            datosTour();
            datosTransporte();
        }
        #region Navbar
        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.Show();
            this.Close();
        }

        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
            this.UpdateLayout();
            datosServicio();
            datosTour();
            datosTransporte();
        }
        
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            DirDepartamentos.GestorDepartamentos depa = new DirDepartamentos.GestorDepartamentos();
            depa.Show();
            this.Close();
        }
        #endregion Navbar

        #region Navegación Servicios
        private void btnRegistrarServicio_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.NuevoServicioExtra ns = new DirServicios.NuevoServicioExtra();
            ns.Show();
        }
        private void btnRegistrarTour_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.NuevoTour nt = new DirServicios.NuevoTour();
            nt.Show();
        }
        private void btnRegistrarTransporte_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.NuevoTransporte ntr = new DirServicios.NuevoTransporte();
            ntr.Show();
        }
        #endregion Navegación Servicios

        #region Servicios
        private void btnActualizarServicio_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdServicio.Text))
            {
                MessageBox.Show("Debe seleccionar un campo de las tablas.");
            } else if (string.IsNullOrEmpty(txt1.Text))
            {
                MessageBox.Show("La descripción no debe estar vacía.");
            } else if (Regex.IsMatch(txt2.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txt2.Text) || int.Parse(txt2.Text) <= 0)
            {
                MessageBox.Show("Debe ser numérico mayor a 0");
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

        private void btnEliminarServicio_Click(object sender, RoutedEventArgs e)
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

        private void btnActualizarTour_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdServicio.Text))
            {
                MessageBox.Show("Debe seleccionar un campo de las tablas.");
            }
            else if (string.IsNullOrEmpty(txt1.Text))
            {
                MessageBox.Show("La descripción no debe estar vacía.");
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

        private void btnEliminarTour_Click(object sender, RoutedEventArgs e)
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

        private void btnEliminarTransporte_Click(object sender, RoutedEventArgs e)
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

        private void btnActualizarTransporte_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdServicio.Text))
            {
                MessageBox.Show("Debe seleccionar un campo de las tablas.");
            } else if (string.IsNullOrEmpty(txt1.Text))
            {
                MessageBox.Show("El nombre no debe estar vacía.");
            } else if (string.IsNullOrEmpty(txt2.Text))
            {
                MessageBox.Show("La patente no debe estar vacía.");
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
        private void datosServicio()
        {
            sc = new ServicioExtraCollection();

            dtgServicios.ItemsSource = sc.ListaServicioExtraC().DefaultView;

            dtgServicios.Items.Refresh();

        }

        private void datosTour()
        {
            tc = new TourCollection();

            dtgTour.ItemsSource = tc.ListaTourC().DefaultView;

            dtgTour.Items.Refresh();

        }

        private void datosTransporte()
        {
            TransporteCollection transc = new TransporteCollection();

            dtgTransporte.ItemsSource = transc.ListaTransporteC().DefaultView;

            dtgTransporte.Items.Refresh();

        }

        private void Limpiar()
        {
            txtIdServicio.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
        }
        #endregion Métodos Custom
    }
}
