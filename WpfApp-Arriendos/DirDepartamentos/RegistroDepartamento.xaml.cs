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

namespace WpfApp_Arriendos.DirDepartamentos
{
    /// <summary>
    /// Lógica de interacción para RegistroDepartamento.xaml
    /// </summary>
    public partial class RegistroDepartamento : Window
    {
        public RegistroDepartamento()
        {
            InitializeComponent();
            slcComuna.IsEnabled = false;
            CargaRegion();
            
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoCollection depa = new DepartamentoCollection();

            int costo = int.Parse(txtCosto.Text);
            string tipo = slcTipo.Text;
            int comuna = int.Parse(slcComuna.SelectedValue.ToString());
            string direccion = txtDireccion.Text;

            var resultado =depa.InsertaDepartamento(costo,tipo,comuna,direccion);

            if (resultado==true)
            {
                lblMensaje.Content = "Registro existoso";
                this.Close();
            }
            else
            {
                lblMensaje.Content = "Error de registro";
            }

        }

        private void CargaRegion()
        {
            DepartamentoCollection depa = new DepartamentoCollection();
            var region = depa.ListaRegion();

            slcRegion.ItemsSource = region.DefaultView;
            
            slcRegion.SelectedValuePath = "ID_REGION";
            slcRegion.DisplayMemberPath = "NOMBRE_REGION";

            DataRow dr = region.NewRow();
            dr["NOMBRE_REGION"] = "Seleccione región";
            region.Rows.InsertAt(dr,0);

            slcRegion.Items.Refresh();
        }

        private void CargaComuna(int region)
        {
            DepartamentoCollection depa = new DepartamentoCollection();

            var comuna = depa.ListaComunaPorRegion(region);

            slcComuna.ItemsSource = comuna.DefaultView;
            slcComuna.SelectedValuePath = "ID_COMUNA";
            slcComuna.DisplayMemberPath = "NOMBRE_COMUNA";

            
            slcComuna.Items.Refresh();

        }

        private void SlcRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (slcRegion.SelectedIndex>0)
            {
                slcComuna.IsEnabled = true;
                int region = int.Parse(slcRegion.SelectedValue.ToString());

                CargaComuna(region);
            }
            else
            {
                
                slcComuna.SelectedIndex = -1;
                slcComuna.IsEnabled = false;
            }
        }


    }
}
