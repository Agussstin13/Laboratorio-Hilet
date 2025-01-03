using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    public partial class MainWindow
    {
        public void LimpiarPacientes()
        {

            boxnombre.Text = "";
            boxapellido.Text = "";
            cmboxciudad.SelectedIndex = -1;
            DateNacimiento.Text = "";
            boxdni.Text = "";
            boxdireccion.Text = "";
            boxaltura.Text = "";
            boxpiso.Text = "";
            boxdepartamento.Text = "";
            boxcorreo.Text = "";
            boxtelefono.Text = "";
        }
        public void LimpiarIngresos()
        {
            cmboxPaciente.SelectedIndex = -1;
            cmboxProfesional.SelectedIndex = -1;
            Datefechaingreso.Text = "";
            Datefecharetiro.Text = "";
        }
        public void LimpiarLocalidades()    
        {
            boxciudad.Text = "";
            boxcodigopostal.Text = "";
        }
        public void LimpiarPersonalMedico()
        {
            boxnombreprofesional.Text = "";
            boxapellidoprofesional.Text = "";
            cmboxservicios.SelectedIndex = -1;
            boxmatriculaprofesional.Text = "";
        }
        public void LimpiarPersonalLaboratorio()
        {
            boxnombrepersonal.Text = "";
            boxapellidopersonal.Text = "";
            boxmatriculapersonal.Text = "";
            cmboxespecialidadespersonal.SelectedIndex = -1;
            cmboxcategoriapersonal.SelectedIndex = -1;
        }
        public void LimpiarCategorias()
        {
            boxcategoria.Text = string.Empty;
        }
        public void LimpiarEspecialidades()
        {
            boxspecialidades.Text = string.Empty;
        }
        public void LimpiarPracticas()
        {
            boxpractica.Text = string.Empty;
            cmboxespecialidadespracticas.SelectedIndex = -1;
            cmboxmuestra.SelectedIndex = -1;
            boxdemora.Text = string.Empty;
        }
        public void LimpiarPracticasxIngreso()
        {
            cmboxpracticas.SelectedIndex = -1;
            cmboxingresos.SelectedIndex = -1;
            boxresultado.Text = string.Empty;
        }
    }
}
