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
using System.Security.Cryptography;
using Negocio.Clases;

namespace WpfApp_Arriendos
{
    public partial class Funcionario : Window
    {
        //Atributos de la vista.
        UsuarioCollection us;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public Funcionario()
        {
            InitializeComponent();
            dtgFuncionarios.IsReadOnly = true;
            Datos();
        }

        #region Navbar

        //Boton que dirige a la vista de Inicio.
        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        //Boton que dirige a la vista Funcionario.
        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
            this.UpdateLayout();
            Datos();
        }

        //Boton que dirige a la vista Departamento.
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            DirDepartamentos.GestorDepartamentos dedpa = new DirDepartamentos.GestorDepartamentos();
            dedpa.Show();
            this.Close();
        }

        //Boton que dirige a la vista Servicios.
        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.Servicio Gs = new DirServicios.Servicio();
            Gs.Show();
            this.Close();
        }
        //Botón que recarga la página
        private void btnRecarga_Click(object sender, RoutedEventArgs e)
        {
            Datos();
        }
        //Botón que minimiza la página
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Botón que cierra la página
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Botón que dirige a la ventana de finanzas
        private void btnFinanzas_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion Navbar

        #region Funcionario

        //Boton que realizar la accion redireccionar a Inicio para realizar registro.
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try {
                DirFuncionario.InicioRegistro ir = new DirFuncionario.InicioRegistro();
                ir.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Tabla que muestra los datos de Funcionario en la vista.
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

        //Boton para realizar la accion de actualizar datos de Usuario.
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("El código no debe estar vacío.");
                }
                else if (Regex.IsMatch(txtId.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Código del funcionario debe ser numérico.");
                }
                else if (string.IsNullOrEmpty(txtDireccion.Text) || txtDireccion.Text.Length < 5 && txtDireccion.Text.Length > 100)
                {
                    MessageBox.Show("Dirección no debe estar vacío y tiene que estar entre 5 a 100 carácteres.");
                }
                else if (string.IsNullOrEmpty(txtContacto.Text) || txtContacto.Text.Length <= 8 && txtContacto.Text.Length >= 10)
                {
                    MessageBox.Show("Campo contacto no debe estar vacío y debe tener 9 dígitos.");
                }
                else if (string.IsNullOrEmpty(txtCorreo.Text))
                {
                    MessageBox.Show("Correo no debe estar vacío.");
                }
                else if (string.IsNullOrEmpty(txtPass.Password))
                {
                    MessageBox.Show("Contraseña no debe estar vacía.");
                }
                else
                {
                    us = new UsuarioCollection();
                    string pass = GetHashString(txtPass.Password);
                    us.ActualizaUsuario(int.Parse(txtId.Text), txtCorreo.Text, txtPass.Password);
                    us.ActualizaDatos(int.Parse(txtId.Text), txtContacto.Text, txtDireccion.Text);

                    lblmensaje.Content = "Actualización correcta!";
                    Limpiar();
                    Datos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de eliminar un Usuario.
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion Funcionario

        #region Métodos Custom

        //Metodo para mostrar los datos de Usuario.
        private void Datos()
        {
            UsuarioCollection uc = new UsuarioCollection();

            dtgFuncionarios.ItemsSource = uc.ListaFuncionarios().DefaultView;

            dtgFuncionarios.Items.Refresh();

        }

        //Metodo para limpiar campos de textos.
        private void Limpiar()
        {
            txtId.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtPass.Password = string.Empty;
        }
        //Método que invoca el sistema de Hash
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        //Método que devuelve el valor cifrado
        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        #endregion Métodos Custom

    }
}
