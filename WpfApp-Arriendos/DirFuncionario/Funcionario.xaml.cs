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

namespace WpfApp_Arriendos
{
    /// <summary>
    /// Lógica de interacción para Funcionario.xaml
    /// </summary>
    public partial class Funcionario : Window
    {
        UsuarioCollection us;
        public Funcionario()
        {
            InitializeComponent();
            dtgFuncionarios.IsReadOnly = true;
            Datos();
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
            this.InvalidateVisual();
            this.UpdateLayout();
            Datos();
        }
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            DirDepartamentos.GestorDepartamentos dedpa = new DirDepartamentos.GestorDepartamentos();
            dedpa.Show();
            this.Close();
        }
        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.Servicio Gs = new DirServicios.Servicio();
            Gs.Show();
            this.Close();
        }
        #endregion Navbar
        #region Funcionario
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            DirFuncionario.InicioRegistro ir = new DirFuncionario.InicioRegistro();
            ir.Show();
        }
        private void DtgFuncionarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd=(DataGrid)sender;

            DataRowView seleccionado = gd.SelectedItem as DataRowView;
            if (seleccionado !=null)
            {
                txtId.Text = seleccionado.Row[0].ToString();
                txtDireccion.Text = seleccionado.Row[3].ToString();
                txtContacto.Text = seleccionado.Row[4].ToString();
                txtCorreo.Text = seleccionado.Row[5].ToString();
                txtPass.Password = seleccionado.Row[6].ToString();
            }
        }
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("El código no debe estar vacío.");
            } else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("La dirección no debe estar vacía.");
            } else if (string.IsNullOrEmpty(txtContacto.Text))
            {
                MessageBox.Show("Contacto no debe estar vacío.");
            } else if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Correo no debe estar vacío.");
            }else if (string.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("Contraseña no debe estar vacía.");
            }
            else
            {
                us = new UsuarioCollection();

                us.ActualizaUsuario(int.Parse(txtId.Text), txtCorreo.Text, txtPass.Password);
                us.ActualizaDatos(int.Parse(txtId.Text), txtContacto.Text, txtDireccion.Text);

                lblmensaje.Content = "Actualización correcta!";
                Limpiar();
                Datos();
            }

        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un campo.");
            }
            else
            {
                us = new UsuarioCollection();

                us.EliminaDatos(int.Parse(txtId.Text));
                us.EliminaUsuario(int.Parse(txtId.Text));

                lblmensaje.Content = "Eliminado!";
                Limpiar();
                Datos();
            }

        }
        #endregion Funcionario
        #region Métodos Custom
        private void Datos()
        {
            UsuarioCollection uc = new UsuarioCollection();

            dtgFuncionarios.ItemsSource = uc.ListaFuncionarios().DefaultView;

            dtgFuncionarios.Items.Refresh();

        }

        private void Limpiar()
        {
            txtId.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtPass.Password = string.Empty;
        }
        #endregion Métodos Custom
    }
}
