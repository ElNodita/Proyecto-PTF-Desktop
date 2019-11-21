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
using Negocio.Clases;

namespace WpfApp_Arriendos.DirFuncionario
{
    public partial class InicioRegistro : Window
    {
        //Atributos de la vista.
        UsuarioCollection uc;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public InicioRegistro()
        {
            InitializeComponent();
        }

        #region Registro Inicial

        //Boton en donde registra un nuevo Usuario.
        private void BtnValida_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCorreo.Text) || CorreoValido(txtCorreo.Text) == false)
                {
                    MessageBox.Show("Correo no debe estar vacío y debe ser en formato de correo");
                }
                else if (string.IsNullOrEmpty(txtPass.Password))
                {
                    MessageBox.Show("Contraseña no debe estar vacía.");
                }
                else
                {
                    uc = new UsuarioCollection();
                    string correo = txtCorreo.Text;
                    var valida = uc.ValidaExistencia(correo);

                    if (valida.Rows.Count > 0)
                    {
                        lblmsj.Content = "Correo ya registrado!";
                    }
                    else
                    {
                        FinRegistro fr = new FinRegistro();
                        uc.InsertaUsuario(correo, txtPass.Password, 2);
                        Application.Current.Resources["appCorreo"] = correo;
                        fr.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion Registro Inicial

        #region Métodos Custom

        //Metodo que valida el formato de correo.
        private bool CorreoValido(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch { return false; }
        }
        #endregion Métodos Custom
    }
}
