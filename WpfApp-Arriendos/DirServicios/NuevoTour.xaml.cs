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
    /// <summary>
    /// Lógica de interacción para NuevoTour.xaml
    /// </summary>
    public partial class NuevoTour : Window
    {
        TourCollection tc;
        public NuevoTour()
        {
            InitializeComponent();
            CargaIdServicio();
        }

        private void btnRegistrarTour_Click(object sender, RoutedEventArgs e)
        {
            if (cbxIdServicioTour.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar un código de servicio.");
            } else if (string.IsNullOrEmpty(txtDescripcionTour.Text))
            {
                MessageBox.Show("El campo descripción no debe estar vacío.");
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
        #region Métodos Custom
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
