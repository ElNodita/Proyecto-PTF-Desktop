using System;
using System.Windows;
using System.Windows.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using Negocio.Clases;

namespace WpfApp_Arriendos.DirFinanzas
{
    /// <summary>
    /// Lógica de interacción para GestorFinanzas.xaml
    /// </summary>
    public partial class GestorFinanzas : Window
    {
        //Atributos de la vista
        FinanzasCollection Fc;
        DepartamentoCollection depa;
        //Constructor de la vista
        public GestorFinanzas()
        {
            InitializeComponent();
            CargaPieChart();
            CargaLineChart();
            CargaRegion();
            CargaCBBMes();
            slcComuna.IsEnabled = false;
            slcDepartamento.IsEnabled = false;
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
            Funcionario Gf = new Funcionario();
            Gf.Show();
            this.Close();
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
        //Botón para ir a finanzas
        private void btnFinanzas_Click(object sender, RoutedEventArgs e)
        {
            //PieChart();
        }
        //Botón que recarga la página
        private void btnRecarga_Click(object sender, RoutedEventArgs e)
        {
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
        #endregion Navbar
        #region Finanza
        //Método de efecto para el gráfico de torta
        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
            foreach (PieSeries pieSeries in chart.Series)
                pieSeries.PushOut = 0;
            var seleccionarSeries = (PieSeries)chartPoint.SeriesView;
            seleccionarSeries.PushOut = 5;
        }
        //Método que genera un archivo pdf
        private void btnInforme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (slcRegion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una región.");
                }
                else if (slcComuna.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una comuna.");
                }
                else if (string.IsNullOrEmpty(txtAño.Text))
                {
                    MessageBox.Show("Debe ingresar un año");
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(txtAño.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("El campo Año debe ser numérico.");
                }
                else if (slcmes.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un mes");
                }
                else if (slcDepartamento.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un departamento");
                }
                else
                {
                    if (!Directory.Exists("C:\\Informes"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory("C:\\Informes");
                        GeneratePDF();
                    }
                    else
                    {
                        GeneratePDF();
                    }
                        
                    lblMensaje.Content = "Informe generado en escritorio.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Combo box que muestra un listado de Regiones y Comunas.
        private void slcRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (slcRegion.SelectedIndex >= 0)
            {
                slcComuna.IsEnabled = true;
                int region = int.Parse(slcRegion.SelectedValue.ToString());

                CargaComuna(region);
            }
            else
            {
                slcComuna.SelectedIndex = -1;
                slcComuna.IsEnabled = false;
            }
        }
        //Combo box que carga comuna y permite habilitar el combo box de departamento
        private void slcComuna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (slcComuna.SelectedIndex >= 0)
            {
                slcDepartamento.IsEnabled = true;
                int comuna = int.Parse(slcComuna.SelectedValue.ToString());

                CargaDepartamento(comuna);
            }
            else
            {
                slcDepartamento.SelectedIndex = -1;
                slcDepartamento.IsEnabled = false;
            }
        }
        #endregion Finanza
        #region Métodos Custom
        //Método para cargar el gráfico de torta
        private void CargaPieChart()
        {
            Fc = new FinanzasCollection();

            var lista = Fc.ListMontoPorRegion();

            foreach (var lt in lista)
            {
                Graf1pc.Series.Add(
                    new PieSeries
                    {
                        Title = lt.Region,
                        StrokeThickness = 0,
                        DataLabels = true,
                        Values = new ChartValues<double> { lt.Monto }
                    });
            }
            DataContext = this;
        }
        //Método para cargar el gráfico de columnas
        private void CargaLineChart()
        {
            Fc = new FinanzasCollection();
            var lista = Fc.IngresoMensual();
            foreach (var lt in lista)
            {
                Graflc.Series.Add(
                    new ColumnSeries
                    {
                        Title = lt.Fecha,
                        StrokeThickness = 0,
                        DataLabels = true,
                        Values = new ChartValues<double> { lt.Ingreso }
                    });
            }
            DataContext = this;
        }

        //Metodo que carga datos de Region.
        private void CargaRegion()
        {
            depa = new DepartamentoCollection();
            var region = depa.ListaRegion();

            slcRegion.ItemsSource = region.DefaultView;
            slcRegion.SelectedValuePath = "ID_REGION";
            slcRegion.DisplayMemberPath = "NOMBRE_REGION";

            slcRegion.Items.Refresh();
        }

        //Metodo que carga datos de Comuna.
        private void CargaComuna(int region)
        {
            depa = new DepartamentoCollection();

            var comuna = depa.ListaComunaPorRegion(region);

            slcComuna.ItemsSource = comuna.DefaultView;
            slcComuna.SelectedValuePath = "ID_COMUNA";
            slcComuna.DisplayMemberPath = "NOMBRE_COMUNA";

            slcComuna.Items.Refresh();
        }

        private void CargaDepartamento(int comuna)
        {
            Fc = new FinanzasCollection();

            var departamento = Fc.ListaDepartamentosComuna(comuna);

            slcDepartamento.ItemsSource = departamento.DefaultView;
            slcDepartamento.SelectedValuePath = "DEPARTAMENTO";
            slcDepartamento.DisplayMemberPath = "DIRECCION";

            slcDepartamento.Items.Refresh();
        }

        //Metodo para verificar estado de Departamento.
        private void CargaCBBMes()
        {
            slcmes.DisplayMemberPath = "Text";
            slcmes.SelectedValuePath = "Value";

            var items = new[] {
                new {Text="Enero",Value=1},
                new { Text = "Febrero", Value = 2 },
                new { Text = "Marzo", Value = 3 },
                new { Text = "Abril", Value = 4},
                new { Text = "Mayo", Value = 5 },
                new { Text = "Junio", Value = 6 },
                new { Text = "Julio", Value = 7 },
                new { Text = "Agosto", Value = 8 },
                new { Text = "Septiembre", Value = 9 },
                new { Text = "Octubre", Value = 10 },
                new { Text = "Noviembre", Value = 11},
                new { Text = "Diciembre", Value = 12}
            };
            slcmes.ItemsSource = items;
        }
        public void GeneratePDF()
        {
            DateTime fecha = DateTime.Now;
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            // Indicamos donde vamos a guardar el documento

                PdfWriter writer = PdfWriter.GetInstance(doc,
                            new FileStream(@"C:\Informes\Prueba.pdf", FileMode.Create));
                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle("Mi primer PDF");
                doc.AddCreator("Turismo Real");

                // Abrimos el archivo
                doc.Open();

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                Paragraph parrafo2 = new Paragraph(string.Format("              REPORTE DEPARTAMENTO"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16));
                parrafo2.SpacingBefore = 200;
                parrafo2.SpacingAfter = 0;
                parrafo2.Alignment = 1; //0-Left, 1 middle,2 Right
                doc.Add(parrafo2);

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("ms-appx:///Assets/img/logo.png");
                img.SetAbsolutePosition(0, 750);
                doc.Add(img);
                img.ScaleToFit(115f, 50F);

                var para = new Paragraph(fecha.ToString());
                para.Alignment = 2;
                para.Font.Size = 12;
                doc.Add(para);

                // Escribimos el encabezamiento en el documento
                doc.Add(new Paragraph("Mi primer documento PDF"));
                doc.Add(Chunk.NEWLINE);

                // Creamos una tabla que contendrá el nombre, apellido y país
                // de nuestros visitante.
                PdfPTable tblPrueba = new PdfPTable(3);
                tblPrueba.WidthPercentage = 100;

                // Configuramos el título de las columnas de la tabla
                PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
                clNombre.BorderWidth = 0;
                clNombre.BorderWidthBottom = 0.75f;

                PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
                clApellido.BorderWidth = 0;
                clApellido.BorderWidthBottom = 0.75f;

                PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
                clPais.BorderWidth = 0;
                clPais.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clApellido);
                tblPrueba.AddCell(clPais);

                // Llenamos la tabla con información
                clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
                clNombre.BorderWidth = 0;

                clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
                clApellido.BorderWidth = 0;

                clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
                clPais.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clApellido);
                tblPrueba.AddCell(clPais);

                doc.Add(tblPrueba);

                doc.Close();
                writer.Close();
             
        }
        #endregion Métodos Custom
    }
}
