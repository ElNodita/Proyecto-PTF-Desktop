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

using Oracle.ManagedDataAccess.Client;


namespace WpfApp_Arriendos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        OracleConnection conexion = new OracleConnection("DATA SOURCE = localhost; PASSWORD = ptfBD ; USER ID = ptfBD");

        private void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            conexion.Open();
            OracleCommand sql = new OracleCommand("select id_usuario from usuario where correo_usuario='"+txtCorreo.Text+"' and contrasena_usuario='"+txtPass.Text+"'",conexion);
            //sql.Parameters.Add("correo",OracleDbType.Varchar2).Value=txtCorreo.Text;
            //sql.Parameters.Add("pass",OracleDbType.Varchar2).Value=txtPass.Text;

            OracleDataReader lector = sql.ExecuteReader();
            if (lector.Read())
            {
                Dashboard dash = new Dashboard();
                dash.Show();
                lblmensaje.Content = "Conexión correcta";
                conexion.Close();
                this.Close();
            }
            else
            {
                lblmensaje.Content = "Error de conexión";
                conexion.Close();
            }
        }
    }
}
