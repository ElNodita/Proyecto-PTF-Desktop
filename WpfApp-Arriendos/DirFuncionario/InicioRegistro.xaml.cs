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
        public InicioRegistro()
        {
            InitializeComponent();
        }

        private void BtnValida_Click(object sender, RoutedEventArgs e)
        {
            UsuarioCollection uc = new UsuarioCollection();
            string correo=txtCorreo.Text;
            var valida = uc.ValidaExistencia(correo);

            if (valida.Rows.Count>0)
            {
                lblmsj.Content = "Correo ya registrado!";
            }
            else
            {
                FinRegistro fr = new FinRegistro();
                uc.InsertaUsuario(correo,txtPass.Password,2);
                Application.Current.Resources["appCorreo"] = correo;
                fr.Show();
                this.Close();
            }
        }
    }
}
