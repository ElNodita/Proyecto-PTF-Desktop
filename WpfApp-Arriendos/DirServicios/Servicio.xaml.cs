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

namespace WpfApp_Arriendos.DirServicios
{
    /// <summary>
    /// Lógica de interacción para Servicio.xaml
    /// </summary>
    public partial class Servicio : Window
    {
        public Servicio()
        {
            InitializeComponent();
            datosServicio();
            datosTour();
            datosTransporte();
        }

        private void datosServicio()
        {
            ServicioExtraCollection sec = new ServicioExtraCollection();

            dtgServicios.ItemsSource = sec.ListaServicioExtraC().DefaultView;

            dtgServicios.Items.Refresh();

        }

        private void datosTour()
        {
            TourCollection tc = new TourCollection();

            dtgTour.ItemsSource = tc.ListaTourC().DefaultView;

            dtgTour.Items.Refresh();

        }

        private void datosTransporte()
        {
            TransporteCollection transc = new TransporteCollection();

            dtgTransporte.ItemsSource = transc.ListaTransporteC().DefaultView;

            dtgTransporte.Items.Refresh();

        }

        private void btnRegistrarServicio_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.NuevoServicioExtra ns = new DirServicios.NuevoServicioExtra();
            ns.Show();
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

        private void btnRegistrarTour_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.NuevoTour nt = new DirServicios.NuevoTour();
            nt.Show();
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

        private void btnRegistrarTransporte_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.NuevoTransporte ntr = new DirServicios.NuevoTransporte();
            ntr.Show();
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

        private void btnActualizarServicio_Click(object sender, RoutedEventArgs e)
        {
            ServicioExtraCollection sc = new ServicioExtraCollection();

            sc.ActualizaServicioExtraC(int.Parse(txtIdServicio.Text), txt1.Text, int.Parse(txt2.Text));

            lblmensaje.Content = "Actualización correcta!";
            datosServicio();
        }

        private void btnEliminarServicio_Click(object sender, RoutedEventArgs e)
        {
            ServicioExtraCollection sc = new ServicioExtraCollection();

            sc.EliminaServicioExtraC(int.Parse(txtIdServicio.Text));

            txtIdServicio.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            lblmensaje.Content = "Eliminado!";

            datosServicio();
        }

        private void btnActualizarTour_Click(object sender, RoutedEventArgs e)
        {

            TourCollection tc = new TourCollection();

            tc.ActualizaTourC(int.Parse(txtIdServicio.Text), txt1.Text);

            lblmensaje.Content = "Actualización correcta!";
            datosTour();
        }

        private void btnEliminarTour_Click(object sender, RoutedEventArgs e)
        {
            TourCollection tc = new TourCollection();

            tc.EliminaTourC(int.Parse(txtIdServicio.Text));

            txtIdServicio.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            lblmensaje.Content = "Eliminado!";

            datosTour();
        }

        private void btnEliminarTransporte_Click(object sender, RoutedEventArgs e)
        {
            TransporteCollection trc = new TransporteCollection();

            trc.EliminaTransporteC(int.Parse(txtIdServicio.Text));

            txtIdServicio.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            lblmensaje.Content = "Eliminado!";

            datosTransporte();
        }

        private void btnActualizarTransporte_Click(object sender, RoutedEventArgs e)
        {
            TransporteCollection trc = new TransporteCollection();

            trc.ActualizaTransporteC(int.Parse(txtIdServicio.Text), txt1.Text, txt2.Text);

            lblmensaje.Content = "Actualización correcta!";
            datosTransporte();
        }

        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            DirDepartamentos.GestorDepartamentos depa = new DirDepartamentos.GestorDepartamentos();
            depa.Show();
            this.Close();
        }
    }
}
