using System;
using System.Collections.Generic;
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
using Negocio.Clases;

namespace WpfApp_Arriendos.DirFuncionario
{
    /// <summary>
    /// Lógica de interacción para FinRegistro.xaml
    /// </summary>
    public partial class FinRegistro : Window
    {
        UsuarioCollection us;
        public FinRegistro()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            DateTime Hoy = DateTime.Now.Date;

            if (string.IsNullOrEmpty(txtRut.Text))
            {
                MessageBox.Show("Rut no debe estar vacío.");
            } else if (ValidaRut(txtRut.Text) == false)
            {
                MessageBox.Show("Formato de Rut inválido.");
            } else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Campo nombre no debe estar vacío.");
            } else if (string.IsNullOrEmpty(txtApellidoPa.Text))
            {
                MessageBox.Show("Campo apellido paterno no debe estar vacío.");
            } else if (string.IsNullOrEmpty(txtApellidoMa.Text))
            {
                MessageBox.Show("Campo apellido materno no debe estar vacío.");
            } else if (string.IsNullOrEmpty(txtFono.Text))
            {
                MessageBox.Show("Campo Fono no debe estar vacío.");
            } else if (cldFechaNac.SelectedDate.Value == DateTime.MinValue.Date)
            {
                MessageBox.Show("Debe selecionar una fecha.");
            } else if (MayoriaEdad(cldFechaNac.SelectedDate.Value) == false)
            {
                MessageBox.Show("Debe ser mayor de edad");
            } else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Campo dirección no debe estar vacío.");
            }
            else
            {
                string correo = Application.Current.Resources["appCorreo"].ToString();

                us = new UsuarioCollection();

                var dato_persona = us.ValidaExistencia(correo);

                int id_usuario = int.Parse(dato_persona.Rows[0]["ID_USUARIO"].ToString());

                string rut = txtRut.Text;
                string nombre = txtNombre.Text;
                string apePa = txtApellidoPa.Text;
                string apeMa = txtApellidoMa.Text;
                string contacto = txtFono.Text;
                DateTime fecha = cldFechaNac.SelectedDate.Value;
                string direccion = txtDireccion.Text;

                var insercion = us.InsertaDatos(rut, nombre, apePa, apeMa, contacto, fecha, direccion, id_usuario);

                if (insercion == true)
                {

                    this.Close();

                }
                else
                {
                    lblmensaje.Content = "Error de inserción.";
                }
            }
        }
        #region Métodos Custom
        private static bool MayoriaEdad(DateTime FechaIngresada)
        {
            int Edad = DateTime.Today.AddTicks(-FechaIngresada.Ticks).Year-1;    
            if (Edad>=18)
            {
                return true;
            }
            return false;
        }
        private static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }
        private static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }
        #endregion Métodos Custom

    }
}
