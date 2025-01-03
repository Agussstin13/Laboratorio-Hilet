using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace T.P_sqlserver
{
    static class CargarComboBox
    {
        static public void CargarCiudades(SqlConnection conexion, ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_localidad FROM Localidades ORDER BY nombre_localidad";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_localidad"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarEspecialidades(SqlConnection conexion, ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_especialidad FROM Especialidades ORDER BY nombre_especialidad";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_especialidad"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarMuestra(SqlConnection conexion, ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_muestra FROM Tipos_de_Muestras ORDER BY nombre_muestra";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_muestra"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarServicios(SqlConnection conexion, ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_servicio FROM Servicios ORDER BY nombre_servicio";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader()) {
                while (reader.Read()) {
                    combobox.Items.Add(reader ["nombre_servicio"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarCategorias (SqlConnection conexion, ComboBox combobox) {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_categoria FROM Categoria ORDER BY nombre_categoria";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader()) {
                while (reader.Read()) {
                    combobox.Items.Add(reader ["nombre_categoria"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarPracticas(SqlConnection conexion, ComboBox combobox)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_practica FROM Practicas ORDER BY nombre_practica";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_practica"].ToString());
                }
                conexion.Close();
            }
        }
        static public void CargarPacientes(SqlConnection conexion, ComboBox combobox, ComboBox id)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_paciente, apellido_paciente, dni, id_pacientes FROM Pacientes ORDER BY nombre_paciente";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_paciente"].ToString() + " " + reader["apellido_paciente"].ToString() + " " + reader["dni"].ToString());
                    id.Items.Add(reader["id_pacientes"]);
                }
                conexion.Close();
            }
        }
        static public void CargarProfesionales(SqlConnection conexion, ComboBox combobox, ComboBox id)
        {
            combobox.Items.Clear();
            string consulta = "SELECT nombre_profesional, apellido_profesional, id_profesionales FROM Profesionales ORDER BY nombre_profesional";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_profesional"].ToString() + " " + reader["apellido_profesional"].ToString());
                    id.Items.Add(reader["id_profesionales"]);
                }
                conexion.Close();
            }
        }
        static public void CargarIngresos(SqlConnection conexion, ComboBox combobox, ComboBox id)
        {
            combobox.Items.Clear();
            string consulta = "SELECT p.nombre_paciente, p.apellido_paciente, p.dni, CONVERT(NVARCHAR(10),i.fecha_ingreso, 103) AS Fecha_Ingreso, CONVERT(NVARCHAR(10),i.fecha_retiro, 103) AS Fecha_Retiro, i.id_ingresos FROM Ingresos i INNER JOIN Pacientes p ON i.id_pacientes = p.id_pacientes ORDER BY p.nombre_paciente";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_paciente"].ToString() + " " + reader["apellido_paciente"].ToString() + " " + reader["dni"].ToString() + " " + reader["Fecha_Ingreso"].ToString() + " " + reader["Fecha_Retiro"].ToString());
                    id.Items.Add(reader["id_ingresos"]);
                }
                conexion.Close();
            }
        }
        static public void CargarPracticas(SqlConnection conexion, ComboBox combobox, ComboBox id)
        {
            combobox.Items.Clear();
            string consulta = "SELECT p.nombre_practica, tp.nombre_muestra, e.nombre_especialidad, p.id_practicas FROM Practicas p INNER JOIN Especialidades e ON e.id_especialidades = p.id_especialidades INNER JOIN Tipos_de_Muestras tp ON tp.id_muestras = p.id_muestras ORDER BY p.nombre_practica";
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    combobox.Items.Add(reader["nombre_practica"].ToString() + " " + reader["nombre_muestra"].ToString() + " " + reader["nombre_especialidad"].ToString());
                    id.Items.Add(reader["id_practicas"]);
                }
                conexion.Close();
            }
        }
    }
}
