using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratorio_Hilet
{
    public partial class MainWindow
    {
        public void ActualizarPacientes()
        {
            try
            {
                string query = "SELECT nombre_paciente AS Nombre, apellido_paciente AS Apellido, nombre_localidad AS Ciudad, CONVERT(NVARCHAR(10),fecha_nacimiento, 103) AS Nacimiento, dni AS DNI, direccion_nombre AS Direccion, direccion_numero AS Altura, direccion_piso AS Piso, direccion_departamento AS departamento, correo AS Correo, telefono AS Telefono, id_pacientes AS ID FROM Pacientes INNER JOIN Localidades ON Pacientes.id_localidades = Localidades.id_localidades";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGPacientes.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarIngresos()
        {
            try
            {
                string query = "SELECT pa.nombre_paciente AS Nombre_Paciente, pa.apellido_paciente AS Apellido_Paciente, pa.dni AS DNI, pr.nombre_profesional AS Nombre_Profesional" +
                    " ,pr.apellido_profesional AS Apellido_Profesional,CONVERT(NVARCHAR(10),I.fecha_ingreso, 103) AS Fecha_Ingreso,CONVERT(NVARCHAR(10),I.fecha_retiro, 103) AS Fecha_Retiro, id_ingresos AS ID FROM Pacientes AS pa INNER JOIN Ingresos" +
                    " AS I ON pa.id_pacientes = I.id_pacientes INNER JOIN Profesionales as pr ON I.id_profesionales = pr.id_profesionales ORDER BY pa.dni;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGIngresos.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarLocalidades()
        {
            try
            {
                string query = "SELECT nombre_Localidad AS Ciudad, codigo_postal AS Codigo_Postal, id_localidades AS ID FROM Localidades";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGLocalidades.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarPersonalMedico()
        {
            try
            {
                string query = "SELECT pro.nombre_profesional AS Nombre, pro.apellido_profesional AS Apellido, pro.matricula_profesional AS Matricula, s.nombre_servicio AS Servicio, id_profesionales AS ID FROM Profesionales AS pro INNER JOIN Servicios AS s ON pro.id_servicios= s.id_servicios ORDER BY pro.id_profesionales;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGMedicos.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarPersonalLaboratorio()
        {
            try
            {
                string query = "SELECT pe.nombre_personal AS Nombre, pe.apellido_personal AS Apellido, pe.matricula_personal AS Matricula, c.nombre_categoria AS Categoria, e.nombre_especialidad AS Especialidad, id_personal AS ID FROM Personal_Laboratorio AS pe INNER JOIN Categoria AS c ON pe.id_categorias = c.id_categorias INNER JOIN Especialidades AS E ON pe.id_especialidades = e.id_especialidades ORDER BY Matricula;";
                using SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                using DataTable dt = new();
                {
                    dataAdapter.Fill(dt);
                    DGPersonalLaboratorio.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarCategorias()
        {
            try
            {
                string query = "SELECT c.nombre_categoria AS Categoria, id_categorias AS ID FROM Categoria AS c ORDER BY c.id_categorias;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGCategorias.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarEspecialidades()
        {
            try
            {
                string query = "SELECT DISTINCT e.nombre_especialidad AS Especialidad, jefes.nombre_categoria AS Categoria, jefes.nombre_personal AS Nombre, jefes.apellido_personal AS Apellido, jefes.matricula_personal AS Matricula, e.id_especialidades AS ID FROM " +
                    "Especialidades AS e LEFT JOIN (SELECT nombre_personal, apellido_personal, matricula_personal, jefes.nombre_categoria, pe.id_categorias, pe.id_especialidades FROM Personal_Laboratorio AS pe INNER JOIN (SELECT id_categorias, nombre_categoria FROM Categoria WHERE nombre_categoria = 'Jefe') AS jefes ON jefes.id_categorias = pe.id_categorias) AS jefes ON e.id_especialidades = jefes.id_especialidades ORDER BY e.nombre_especialidad;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGEspecialidades.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarPracticas()
        {
            try
            {
                string query = "SELECT nombre_practica AS Practica, nombre_especialidad AS Especialidad, nombre_muestra AS Muestra, tiempo_demora_practica AS Demora, id_practicas AS ID FROM Practicas INNER JOIN Especialidades ON Practicas.id_especialidades = Especialidades.id_especialidades INNER JOIN Tipos_de_Muestras ON Practicas.id_muestras = Tipos_de_Muestras.id_muestras";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGPracticas.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarPracticasIngreso()
        {
            try
            {
                string query = "SELECT pra.nombre_practica AS Practica, m.nombre_muestra AS Muestra, e.nombre_especialidad AS Especialidad, pa.nombre_paciente AS Nombre, pa.apellido_paciente AS Apellido, pa.dni AS DNI, CONVERT(NVARCHAR(10),i.fecha_ingreso, 103) AS Fecha_Ingreso, CONVERT(NVARCHAR(10),i.fecha_retiro, 103) AS Fecha_Retiro, pxi.resultado AS Resultado, pxi.id_practicasxingreso AS ID FROM Pacientes AS pa INNER JOIN Ingresos AS i ON pa.id_pacientes = i.id_pacientes INNER JOIN PracticasxIngreso AS pxi ON i.id_ingresos = pxi.id_ingresos INNER JOIN Practicas AS pra ON pxi.id_practicas = pra.id_practicas INNER JOIN Tipos_de_Muestras AS m ON pra.id_muestras = m.id_muestras INNER JOIN Especialidades AS e ON pra.id_especialidades=e.id_especialidades ORDER BY pa.dni;";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion))
                using (DataTable dt = new DataTable())
                {
                    dataAdapter.Fill(dt);
                    DGPracticasIngresos.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Todo() {
            try
            {
                ActualizarPacientes();
                ActualizarIngresos();
                ActualizarLocalidades();
                ActualizarPersonalMedico();
                ActualizarPersonalLaboratorio();
                ActualizarCategorias();
                ActualizarEspecialidades();
                ActualizarPracticas();
                ActualizarPracticasIngreso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
