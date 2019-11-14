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
    /// <summary>
    /// Lógica de interacción para InicioRegistro.xaml
    /// </summary>
    public partial class InicioRegistro : Window
    {
        UsuarioCollection uc;
        public InicioRegistro()
        {
            InitializeComponent();
        }
        #region Registro Inicial
        private void BtnValida_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text) || CorreoValido(txtCorreo.Text)==false)
            {
                MessageBox.Show("Correo no debe estar vacío y debe ser en formato de correo");
            } else if (string.IsNullOrEmpty(txtPass.Password))
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
        #endregion Registro Inicial

        #region Métodos Custom
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
