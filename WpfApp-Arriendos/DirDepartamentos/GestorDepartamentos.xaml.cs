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

namespace WpfApp_Arriendos.DirDepartamentos
{
    /// <summary>
    /// Lógica de interacción para GestorDepartamentos.xaml
    /// </summary>
    public partial class GestorDepartamentos : Window
    {
        public GestorDepartamentos()
        {
            InitializeComponent();
            dtgDepartamento.IsReadOnly = true;
            Datos();
            
        }

        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.Show();
            this.Close();
        }

        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
            this.UpdateLayout();
            Datos();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        private void BtnFinanzas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnServicios_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroDepartamento regDepa = new RegistroDepartamento();
            regDepa.Show();
        }

        private void Datos()
        {
            DepartamentoCollection depa = new DepartamentoCollection();

            dtgDepartamento.ItemsSource = depa.ListaDepartamento().DefaultView;
            dtgDepartamento.Items.Refresh();
            
        }

        private void DtgDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;

            DataRowView seleccionado = gd.SelectedItem as DataRowView;
            if (seleccionado!=null)
            {
                CargaCBBEstado();
                CargaCBBTipo();
                txtId.Text = seleccionado.Row[0].ToString();
                txtDireccion.Text = seleccionado.Row[1].ToString();
                txtCosto.Text = seleccionado.Row[2].ToString();
            }
        }

        private void BtnActualizarDepa_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoCollection depa = new DepartamentoCollection();
            int id = int.Parse(txtId.Text);
            int costo = int.Parse(txtCosto.Text);
            string direccion = txtDireccion.Text;
            string tipo = slcTipo.SelectedValue.ToString();
            char estado = char.Parse(slcEstado.SelectedValue.ToString());

            depa.ActualizaDepartamento(id,costo,estado,tipo,direccion);

            lblMensajeDatos.Content = "Actualización correcta";

            Datos();
            Limpiar();
        }

        private void BtnEliminarDepa_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoCollection depa = new DepartamentoCollection();

            int id = int.Parse(txtId.Text);

            depa.EliminarDepartamento(id);

            lblMensajeDatos.Content = "Eliminación correcta";

            Datos();
            Limpiar();
        }

        private void CargaCBBEstado()
        {
            slcEstado.DisplayMemberPath = "Text";
            slcEstado.SelectedValuePath = "Value";

            var items = new[] {
                new {Text="Listo",Value=1},
                new { Text = "No Listo", Value = 0 }
            };

            slcEstado.ItemsSource = items;

        }

        private void CargaCBBTipo()
        {
            slcTipo.DisplayMemberPath = "Text";
            slcTipo.SelectedValuePath = "Value";

            var items = new[] {
                new {Text="Básico",Value="Básico"},
                new {Text="Estándar",Value = "Estándar"},
                new {Text="Premium",Value = "Premium"}
            };

            slcTipo.ItemsSource = items;

        }

        private void Limpiar()
        {
            txtId.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            slcEstado.Text = string.Empty;
            slcTipo.Text = string.Empty;
        }
    }
}
