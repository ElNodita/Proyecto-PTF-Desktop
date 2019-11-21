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
    public partial class FinRegistro : Window
    {
        //Atributos de la vista.
        UsuarioCollection us;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public FinRegistro()
        {
            InitializeComponent();
        }

        //Boton para realizar la accion de ingreso datos de Usuario.
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime Hoy = DateTime.Now.Date;

                if (string.IsNullOrEmpty(txtRut.Text) || txtRut.Text.Length <= 8 && txtRut.Text.Length >=11)
                {
                    MessageBox.Show("Rut no debe estar vacío y debe que tener el siguente formato 12345678-9.");
                }
                else if (ValidaRut(txtRut.Text) == false)
                {
                    MessageBox.Show("Formato de Rut inválido (12345678-9).");
                }
                else if (!(Regex.IsMatch(txtNombre.Text, "^[a-zA-Z]")) || string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Campo nombre no debe estar vacío.");
                }
                else if (txtNombre.Text.Length <=2 && txtNombre.Text.Length >= 101)
                {
                    MessageBox.Show("Campo nombre debe estar entre 3 a 100 carácteres.");
                }
                else if (!(Regex.IsMatch(txtApellidoPa.Text, "^[a-zA-Z]")) || string.IsNullOrEmpty(txtApellidoPa.Text))
                {
                    MessageBox.Show("Campo apellido paterno no debe estar vacío.");
                }
                else if (txtApellidoPa.Text.Length <= 2 && txtApellidoMa.Text.Length >= 101)
                {
                    MessageBox.Show("Campo apellido paterno debe estar entre 3 a 100 carácteres.");
                }
                else if (!(Regex.IsMatch(txtApellidoMa.Text, "^[a-zA-Z]")) || string.IsNullOrEmpty(txtApellidoMa.Text))
                {
                    MessageBox.Show("Campo apellido materno no debe estar vacío.");
                }
                else if (txtApellidoMa.Text.Length <= 2 && txtApellidoMa.Text.Length >= 101)
                {
                    MessageBox.Show("Campo apellido materno debe estar entre 3 a 100 carácteres.");
                }
                else if (string.IsNullOrEmpty(txtFono.Text) || txtFono.Text.Length <=8 && txtFono.Text.Length >=10)
                {
                    MessageBox.Show("Campo Fono no debe estar vacío y debe tener 9 dígitos.");
                }
                else if (Regex.IsMatch(txtFono.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Campo Fono no debe letras.");
                }
                else if (cldFechaNac.SelectedDate == null)
                {
                    MessageBox.Show("Debe selecionar una fecha.");
                }
                else if (MayoriaEdad(cldFechaNac.SelectedDate.Value) == false)
                {
                    MessageBox.Show("Debe ser mayor de edad");
                }
                else if (string.IsNullOrEmpty(txtDireccion.Text) || txtDireccion.Text.Length < 5 && txtDireccion.Text.Length > 100)
                {
                    MessageBox.Show("Dirección no debe estar vacío y tiene que estar entre 5 a 100 carácteres.");
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
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #region Métodos Custom

        //Metodo para verificar que el Usuario sea mayor de Edad.
        private static bool MayoriaEdad(DateTime FechaIngresada)
        {
            int Edad = DateTime.Today.AddTicks(-FechaIngresada.Ticks).Year-1;    
            if (Edad>=18)
            {
                return true;
            }
            return false;
        }

        //Metodo para validar de que el Rut sea correcto.
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

        //Metodo para validar el digito verificador del Rut de Usuario.
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
