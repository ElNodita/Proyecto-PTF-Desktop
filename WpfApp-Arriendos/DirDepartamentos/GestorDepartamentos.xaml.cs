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
            InventarioInvisible();
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

                int inventario = int.Parse(seleccionado.Row[7].ToString());

                if (inventario > 0)
                {
                    InventarioVisible();
                    lblMensajeInventario.Content = string.Empty;
                    btnRegistraInv.Visibility = Visibility.Hidden;
                    txtInventario.Text = inventario.ToString();
                }
                else
                {
                    InventarioInvisible();
                    lblMensajeInventario.Content = "No posee inventario, registre uno";
                    btnRegistraInv.Visibility = Visibility.Visible;
                }

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

        private void InventarioInvisible()
        {
            txtInventario.Visibility = Visibility.Hidden;
            chkInternet.Visibility = Visibility.Hidden;
            txtBaño.Visibility = Visibility.Hidden;
            txtDormitorio.Visibility = Visibility.Hidden;
            txtTv.Visibility = Visibility.Hidden;
            txtMesas.Visibility = Visibility.Hidden;
            txtAsiento.Visibility = Visibility.Hidden;
            txtMuebles.Visibility = Visibility.Hidden;

            lblInventario.Visibility = Visibility.Hidden;
            lblBaño.Visibility = Visibility.Hidden;
            lblDormitorio.Visibility = Visibility.Hidden;
            lblTv.Visibility = Visibility.Hidden;
            lblMesas.Visibility = Visibility.Hidden;
            lblAsiento.Visibility = Visibility.Hidden;
            lblMueble.Visibility = Visibility.Hidden;

            btnActualizarInv.Visibility = Visibility.Hidden;
            btnEliminarInv.Visibility = Visibility.Hidden;
        }
        private void InventarioVisible()
        {
            txtInventario.Visibility = Visibility.Visible;
            chkInternet.Visibility = Visibility.Visible;
            txtBaño.Visibility = Visibility.Visible;
            txtDormitorio.Visibility = Visibility.Visible;
            txtTv.Visibility = Visibility.Visible;
            txtMesas.Visibility = Visibility.Visible;
            txtAsiento.Visibility = Visibility.Visible;
            txtMuebles.Visibility = Visibility.Visible;

            lblInventario.Visibility = Visibility.Visible;
            lblBaño.Visibility = Visibility.Visible;
            lblDormitorio.Visibility = Visibility.Visible;
            lblTv.Visibility = Visibility.Visible;
            lblMesas.Visibility = Visibility.Visible;
            lblAsiento.Visibility = Visibility.Visible;
            lblMueble.Visibility = Visibility.Visible;

            btnActualizarInv.Visibility = Visibility.Visible;
            btnEliminarInv.Visibility = Visibility.Visible;
        }

        private void BtnRegistraInv_Click(object sender, RoutedEventArgs e)
        {
            RegistraInventario inv = new RegistraInventario();
            Application.Current.Resources["id_departamento"] = txtId.Text;
            inv.Show();
        }

        private void BtnEliminarInv_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoCollection inv = new DepartamentoCollection();
            int inventario = int.Parse(txtInventario.Text);
            var resultado = inv.EliminaInventario(inventario);
            if (resultado ==true)
            {
                inv.CambiaEstado(int.Parse(txtId.Text),char.Parse(0.ToString()));
                lblMensajeInventario.Content = "Eliminado corrrectamente!";
            }
            else
            {
                lblMensajeInventario.Content = "Error al eliminar";
            }
        }

        private void BtnActualizarInv_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoCollection inv = new DepartamentoCollection();

            int id = int.Parse(txtInventario.Text);
            char internet;
            if (chkInternet.IsChecked == true)
            {
                internet = char.Parse(1.ToString());
            }
            else
            {
                internet = char.Parse(0.ToString());
            }
            int baños = int.Parse(txtBaño.Text);
            int dormitorio = int.Parse(txtDormitorio.Text);
            int tv = int.Parse(txtTv.Text);
            int mesa = int.Parse(txtMesas.Text);
            int asiento = int.Parse(txtAsiento.Text);
            int mueble = int.Parse(txtMuebles.Text);

            inv.ActualizaInventario(id,internet,baños,dormitorio,tv,mesa,asiento,mueble);

            lblMensajeInventario.Content = "Actualización correcta!";

        }
    }
}
