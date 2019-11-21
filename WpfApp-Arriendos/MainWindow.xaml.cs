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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Negocio.Clases;



namespace WpfApp_Arriendos
{
    public partial class MainWindow : Window
    {
        UsuarioCollection usuario;
        //Constructor de la clase donde se indica como debe iniciar la vista.
        public MainWindow()
        {
            InitializeComponent();
        }

        //Boton que realiza la accion de iniciar sesion con un Usuario existente en la base de datos.
        private void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                usuario = new UsuarioCollection();

                string correo = txtCorreo.Text;
                string pass = txtPass.Password;

                var valida = usuario.IniciarSesion(correo, pass);

                if (valida.Rows.Count > 0)
                {
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    this.Close();
                }
                else
                {
                    lblmensaje.Content = "Usuario no válido.";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
