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
    /// Lógica de interacción para NuevoTransporte.xaml
    /// </summary>
    public partial class NuevoTransporte : Window
    {
        TransporteCollection trc;
        public NuevoTransporte()
        {
            InitializeComponent();
            CargaIdServicio();
        }

        private void btnRegistrarTransporte_Click(object sender, RoutedEventArgs e)
        {
            if (cbxIdServicioTransporte.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar un servicio.");
            } else if (string.IsNullOrEmpty(txtNombreConductor.Text))
            {
                MessageBox.Show("El campo nombre no dee estar vacío.");
            } else if (string.IsNullOrEmpty(txtPatente.Text))
            {
                MessageBox.Show("El campo patente no debe estar vacío.");
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
        #region Métodos Custom
        private void CargaIdServicio()
        {
            ServicioExtraCollection sc = new ServicioExtraCollection();
            var servicio = sc.ListaServicioExtraC();

            cbxIdServicioTransporte.ItemsSource = servicio.DefaultView;

            cbxIdServicioTransporte.SelectedValuePath = "ID_SERVICIO";
            cbxIdServicioTransporte.DisplayMemberPath = "ID_SERVICIO";

            cbxIdServicioTransporte.Items.Refresh();
        }
        #endregion Métodos Custom
    }
}
