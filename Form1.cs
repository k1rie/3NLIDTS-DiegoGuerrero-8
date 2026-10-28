using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _3NLIDTS_DiegoGuerrero_8
{
    public partial class Form1 : Form
    {
        string SQLConection = "Server=localhost;Port=3306;Database=progavanzada;Uid=root;Pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insertarRegistros(string nombre, string apellidos, int edad, decimal estatura, string telefono, string genero)
        {
            using (MySqlConnection conectar = new MySqlConnection(SQLConection))
            {
                conectar.Open(); string insertQuery = "INSERT INTO BasePA (nombre, apellidos, telefono, estatura, edad, genero) " + "VALUES (@nombre, @apellidos,@telefono,@estatura, @edad, @genero)";
                using (MySqlCommand comando = new MySqlCommand(insertQuery, conectar))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@apellidos", apellidos);
                    comando.Parameters.AddWithValue("@telefono", telefono);
                    comando.Parameters.AddWithValue("@estatura", estatura);
                    comando.Parameters.AddWithValue("@edad", edad);
                    comando.Parameters.AddWithValue("@genero", genero);
                    comando.ExecuteNonQuery();
                }
                conectar.Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txbNombre.Text;
            string apellidos = txbApellidos.Text;
            string telefono = txbTelefono.Text;
            string edad = txbEdad.Text;
            string estatura = txbEstatura.Text;
            string genero = "";
            if (rbFemenino.Checked)
            {
                genero = "Femenino";
            }
            else if (rbMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbOtro.Checked)
            {
                genero = "Otro";
            }
            //Crear una cadena con los datos
            string datos = $"Nombres: {nombre}\r\nApellidos: {apellidos} \r\nTeléfono: {telefono} " + $"\r\nEstatura: {estatura} m\r\nEdad: {edad} años\r\nGénero: {genero}\r\n";
            // Guardar los datos en un archivo de texto (carpeta Documentos del usuario actual)
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "3NAgoDic26.txt");
            bool archivoExiste = File.Exists(rutaArchivo);
            if (archivoExiste == false)
            {
                File.WriteAllText(rutaArchivo, datos);
            }
            else
            {
                // Verificar si el archivo ya existe
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    if (archivoExiste)
                    { // Si el archivo existe, añadir un separador antes del nuevo registro
                        writer.WriteLine();
                    }
                    writer.WriteLine(datos);
                }
            }
            // Insertar en la Base de Datos (se hace siempre, exista o no el archivo)
            insertarRegistros(nombre, apellidos, int.Parse(edad), decimal.Parse(estatura, CultureInfo.InvariantCulture), telefono, genero);
            MessageBox.Show("Datos insertados en la Base de Datos:\n\n" + datos, "BasePA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Mostrar un mensaje con los datos capturados
            MessageBox.Show("Datos guardados con éxito:\n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbNombre.Clear();
            txbApellidos.Clear();
            txbTelefono.Clear();
            txbEstatura.Clear();
            txbEdad.Clear();
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            rbOtro.Checked = false;
            txbNombre.Focus();
        }
    }
}
