using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Negocio.Clases;

namespace WpfApp_Arriendos.DirServicios
{
    public partial class NuevoTransporte : Window
    {
        //Atributos de la vista.
        TransporteCollection trc;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public NuevoTransporte()
        {
            InitializeComponent();
            CargaIdServicio();
        }
        //Botón para minimizar la pestaña
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Botón para cerrar la ventana
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Boton para realizar la accion de ingresar datos de Transporte.
        private void btnRegistrarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbxIdServicioTransporte.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un servicio.");
                }
                else if (string.IsNullOrEmpty(txtNombreConductor.Text) || txtNombreConductor.Text.Length < 3 && txtNombreConductor.Text.Length > 100)
                {
                    MessageBox.Show("Nombre no debe estar vacío y tiene que estar entre 3 a 100 carácteres.");
                }
                else if (string.IsNullOrEmpty(txtPatente.Text) || txtPatente.Text.Length >= 9)
                {
                    MessageBox.Show("El campo patente no debe estar vacío y ser mayor a 8 carácteres.");
                }
                else if (!Regex.IsMatch(txtPatente.Text, "^[a-zA-Z]{2}[-][a-zA-Z]{2}[-][0-9]{2}$"))
                {
                    MessageBox.Show("El campo patente debe tener formato AA-AA-99.");
                }
                else
                {
                    trc = new TransporteCollection();

                    int id_servicio = int.Parse(cbxIdServicioTransporte.SelectedValue.ToString());
                    string nombreConductor = txtNombreConductor.Text;
                    string patente = txtPatente.Text;

                    var insercion = trc.InsertaTransporteC(nombreConductor, patente, id_servicio);

                    if (insercion == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        lblmensaje.Content = "Error de inserción.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #region Métodos Custom

        //Metodo para guardar Transporte en la Id de Servicio extra.
        private void CargaIdServicio()
        {
            ServicioExtraCollection sc = new ServicioExtraCollection();
            var servicio = sc.ListaServicioExtraC();

            cbxIdServicioTransporte.ItemsSource = servicio.DefaultView;

            cbxIdServicioTransporte.SelectedValuePath = "CÓDIGO";
            cbxIdServicioTransporte.DisplayMemberPath = "CÓDIGO";

            cbxIdServicioTransporte.Items.Refresh();
        }
        #endregion Métodos Custom
    }
}
