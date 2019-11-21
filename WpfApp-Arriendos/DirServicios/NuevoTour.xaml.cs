using System;
using System.Collections.Generic;
using System.Data;
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
using Negocio.Clases;

namespace WpfApp_Arriendos.DirServicios
{
    public partial class NuevoTour : Window
    {
        //Atributos de la vista.
        TourCollection tc;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public NuevoTour()
        {
            InitializeComponent();
            CargaIdServicio();
        }

        //Boton para realizar la accion de ingresar datos de Tour.
        private void btnRegistrarTour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbxIdServicioTour.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un código de servicio.");
                }
                else if (string.IsNullOrEmpty(txtDescripcionTour.Text) || txtDescripcionTour.Text.Length < 5 && txtDescripcionTour.Text.Length > 200)
                {
                    MessageBox.Show("Descripción no debe estar vacío y tiene que estar entre 5 a 200 carácteres.");
                }
                else
                {
                    tc = new TourCollection();

                    int id_servicio = int.Parse(cbxIdServicioTour.SelectedValue.ToString());
                    string descripcion = txtDescripcionTour.Text;

                    var insercion = tc.InsertaTourC(id_servicio, descripcion);

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

        //Metodo para guardar Tour en la Id de Servicio extra.
        private void CargaIdServicio()
        {
            ServicioExtraCollection sc = new ServicioExtraCollection();
            var servicio = sc.ListaServicioExtraC();

            cbxIdServicioTour.ItemsSource = servicio.DefaultView;

            cbxIdServicioTour.SelectedValuePath = "ID_SERVICIO";
            cbxIdServicioTour.DisplayMemberPath = "ID_SERVICIO";

            cbxIdServicioTour.Items.Refresh();

        }
        #endregion Métodos Custom
    }
}
