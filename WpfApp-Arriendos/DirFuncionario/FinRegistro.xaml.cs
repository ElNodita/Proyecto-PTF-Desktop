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
    /// Lógica de interacción para FinRegistro.xaml
    /// </summary>
    public partial class FinRegistro : Window
    {
        public FinRegistro()
        {
            InitializeComponent();
            
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string correo = Application.Current.Resources["appCorreo"].ToString();

            UsuarioCollection us = new UsuarioCollection();

            var dato_persona = us.ValidaExistencia(correo);

            int id_usuario = int.Parse(dato_persona.Rows[0]["ID_USUARIO"].ToString());

            string rut = txtRut.Text;
            string nombre = txtNombre.Text;
            string apePa = txtApellidoPa.Text;
            string apeMa = txtApellidoMa.Text;
            string contacto = txtFono.Text;
            DateTime fecha = cldFechaNac.SelectedDate.Value;
            string direccion = txtDireccion.Text;

            var insercion = us.InsertaDatos(rut,nombre,apePa,apeMa,contacto,fecha,direccion,id_usuario);

            if (insercion==true)
            {

                this.Close();

            }
            else
            {
                lblmensaje.Content = "Error de inserción.";
            }


        }
    }
}
