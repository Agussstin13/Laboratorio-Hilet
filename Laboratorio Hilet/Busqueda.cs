using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Net;

namespace Laboratorio_Hilet
{
    partial class MainWindow
    {


        private void boxbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(!(boxbusqueda.Text == string.Empty))
                {
                    switch (selectedview)
                    {
                        case 1:
                            try
                            {
                                string query = "SELECT nombre_paciente AS Nombre, apellido_paciente AS Apellido, nombre_localidad AS Ciudad, CONVERT(NVARCHAR(10),fecha_nacimiento, 103) AS Nacimiento, dni AS DNI, direccion_nombre AS Direccion, direccion_numero AS Altura, direccion_piso AS Piso, direccion_departamento AS departamento, correo AS Correo, telefono AS Telefono, id_pacientes AS ID FROM Pacientes INNER JOIN Localidades ON Pacientes.id_localidades = Localidades.id_localidades" +
                                " WHERE LOWER(nombre_paciente) LIKE @busqueda OR LOWER(apellido_paciente) LIKE @busqueda OR LOWER(nombre_localidad) LIKE @busqueda OR LOWER(fecha_nacimiento) LIKE @busqueda OR LOWER(dni) LIKE @busqueda OR LOWER(direccion_nombre) LIKE @busqueda OR LOWER(direccion_numero) LIKE @busqueda OR LOWER(direccion_piso) LIKE @busqueda OR LOWER(direccion_departamento) LIKE @busqueda OR LOWER(correo) LIKE @busqueda OR LOWER(telefono) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGPacientes.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 2:
                            try
                            {
                                string query =  "SELECT pa.nombre_paciente AS Nombre_Paciente, pa.apellido_paciente AS Apellido_Paciente, pa.dni AS DNI, pr.nombre_profesional AS Nombre_Profesional" +
                                                " ,pr.apellido_profesional AS Apellido_Profesional,CONVERT(NVARCHAR(10),I.fecha_ingreso, 103) AS Fecha_Ingreso,CONVERT(NVARCHAR(10),I.fecha_retiro, 103) AS Fecha_Retiro, id_ingresos AS ID FROM Pacientes AS pa INNER JOIN Ingresos" +
                                                " AS I ON pa.id_pacientes = I.id_pacientes INNER JOIN Profesionales as pr ON I.id_profesionales = pr.id_profesionales "+
                                                "WHERE LOWER (pa.nombre_paciente) LIKE @busqueda OR LOWER (pa.apellido_paciente) LIKE @busqueda OR LOWER (pa.dni) LIKE @busqueda OR LOWER (pr.nombre_profesional) LIKE @busqueda OR LOWER (pr.apellido_profesional) LIKE @busqueda "+
                                                "OR LOWER (I.fecha_ingreso) LIKE @busqueda OR LOWER (I.fecha_retiro) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGIngresos.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 3:
                            try
                            {
                                string query = "SELECT nombre_Localidad AS Ciudad, codigo_postal AS Codigo_Postal, id_localidades AS ID FROM Localidades WHERE LOWER (nombre_Localidad) LIKE @busqueda OR LOWER(codigo_postal) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGLocalidades.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 4:
                            try
                            {
                                string query = "SELECT pro.nombre_profesional AS Nombre, pro.apellido_profesional AS Apellido, pro.matricula_profesional AS Matricula, s.nombre_servicio AS Servicio, id_profesionales AS ID FROM Profesionales AS pro INNER JOIN Servicios AS s ON pro.id_servicios= s.id_servicios WHERE LOWER(pro.nombre_profesional) LIKE @busqueda OR LOWER (pro.apellido_profesional) LIKE @busqueda OR LOWER (pro.matricula_profesional) LIKE @busqueda OR LOWER (s.nombre_servicio) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGMedicos.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 5:
                            try
                            {
                                string query = "SELECT pe.nombre_personal AS Nombre, pe.apellido_personal AS Apellido, pe.matricula_personal AS Matricula, c.nombre_categoria AS Categoria, e.nombre_especialidad AS Especialidad, id_personal AS ID FROM Personal_Laboratorio AS pe INNER JOIN Categoria AS c ON pe.id_categorias = c.id_categorias INNER JOIN Especialidades AS E ON pe.id_especialidades = e.id_especialidades WHERE LOWER(pe.nombre_personal) LIKE @busqueda OR LOWER (pe.apellido_personal) LIKE @busqueda OR LOWER (pe.matricula_personal) LIKE @busqueda OR LOWER (c.nombre_categoria) LIKE @busqueda OR LOWER (e.nombre_especialidad) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGPersonalLaboratorio.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 6:
                            try
                            {
                                string query = "SELECT c.nombre_categoria AS Categoria, id_categorias AS ID FROM Categoria AS c WHERE LOWER (c.nombre_categoria) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGCategorias.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 7:
                            try
                            {
                                
                                string query = "SELECT DISTINCT e.nombre_especialidad AS Especialidad, jefes.nombre_categoria AS Categoria, jefes.nombre_personal AS Nombre, jefes.apellido_personal AS Apellido, jefes.matricula_personal AS Matricula,"+
                                    "e.id_especialidades AS ID FROM Especialidades AS e LEFT JOIN (SELECT nombre_personal, apellido_personal, matricula_personal, jefes.nombre_categoria, pe.id_categorias, pe.id_especialidades FROM Personal_Laboratorio AS pe INNER JOIN (SELECT id_categorias, nombre_categoria FROM Categoria WHERE nombre_categoria = 'Jefe') AS jefes ON jefes.id_categorias = pe.id_categorias)" +
                                    "AS jefes ON e.id_especialidades = jefes.id_especialidades WHERE LOWER (e.nombre_especialidad) LIKE @busqueda OR LOWER (jefes.nombre_categoria) LIKE @busqueda OR LOWER (jefes.nombre_personal) LIKE @busqueda "+
                                    "OR LOWER (jefes.apellido_personal) LIKE @busqueda OR LOWER (jefes.matricula_personal) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGEspecialidades.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 8:
                            try
                            {
                                string query = "SELECT nombre_practica AS Practica, nombre_especialidad AS Especialidad, nombre_muestra AS Muestra, tiempo_demora_practica AS Demora, id_practicas AS ID FROM Practicas INNER JOIN Especialidades ON Practicas.id_especialidades = Especialidades.id_especialidades INNER JOIN Tipos_de_Muestras ON Practicas.id_muestras = Tipos_de_Muestras.id_muestras WHERE LOWER (nombre_practica) LIKE @busqueda OR LOWER (nombre_especialidad) LIKE @busqueda OR LOWER (nombre_muestra) LIKE @busqueda OR LOWER (tiempo_demora_practica) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGPracticas.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 9:
                            try
                            {
                                string query = "SELECT pra.nombre_practica AS Practica, m.nombre_muestra AS Muestra, e.nombre_especialidad AS Especialidad, pa.nombre_paciente AS Nombre, pa.apellido_paciente AS Apellido, pa.dni AS DNI, CONVERT(NVARCHAR(10),i.fecha_ingreso, 103) AS Fecha_Ingreso, CONVERT(NVARCHAR(10),i.fecha_retiro, 103) AS Fecha_Retiro, pxi.resultado AS Resultado, pxi.id_practicasxingreso AS ID FROM Pacientes AS pa INNER JOIN Ingresos AS i ON pa.id_pacientes = i.id_pacientes INNER JOIN PracticasxIngreso AS pxi ON i.id_ingresos = pxi.id_ingresos INNER JOIN Practicas AS pra ON pxi.id_practicas = pra.id_practicas INNER JOIN Tipos_de_Muestras AS m ON pra.id_muestras = m.id_muestras INNER JOIN Especialidades AS e ON pra.id_especialidades=e.id_especialidades " +
                                    "WHERE LOWER (pra.nombre_practica) LIKE @busqueda OR LOWER (m.nombre_muestra) LIKE @busqueda OR LOWER (e.nombre_especialidad) LIKE @busqueda OR LOWER (pa.nombre_paciente) LIKE @busqueda OR LOWER (pa.apellido_paciente) LIKE @busqueda OR LOWER (pa.dni) LIKE @busqueda OR LOWER (i.fecha_ingreso) LIKE @busqueda OR LOWER (i.fecha_retiro) LIKE @busqueda OR LOWER (pxi.resultado) LIKE @busqueda";
                                using (SqlCommand command = new SqlCommand(query, conexion))
                                {
                                    command.Parameters.AddWithValue("@busqueda", string.IsNullOrWhiteSpace(boxbusqueda.Text) ? DBNull.Value : "%" + boxbusqueda.Text.ToLower() + "%");
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    using (DataTable dt = new DataTable())
                                    {
                                        dataAdapter.Fill(dt);
                                        DGPracticasIngresos.ItemsSource = dt.DefaultView;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                    }
                }
                else
                {
                    switch (selectedview)
                    {
                        case 1:
                            ActualizarPacientes();
                            break;
                        case 2:
                            ActualizarIngresos();
                            break;
                        case 3:
                            ActualizarLocalidades();
                            break;
                        case 4:
                            ActualizarPersonalMedico();
                            break;
                        case 5:
                            ActualizarPersonalLaboratorio();
                            break;
                        case 6:
                            ActualizarCategorias();
                            break;
                        case 7:
                            ActualizarEspecialidades();
                            break;
                        case 8:
                            ActualizarPracticas();
                            break;
                        case 9:
                            ActualizarPracticasIngreso();
                            break;
                    }
                }
            }
        }
    }
}
