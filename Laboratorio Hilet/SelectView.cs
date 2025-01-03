using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using T.P_sqlserver;

namespace Laboratorio_Hilet
{
    partial class MainWindow
    {

        public void ViewPacientes()
        {
            GPacientes.Visibility = Visibility.Visible;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewIngresos()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Visible;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        //Usamos bandera para que se muestren o no los botones que van dentro de laboratorio
        bool flagLaboratorio = false;
        public void ViewLaboratorio()
        {
            if (flagLaboratorio)
            {
                btnLocalidades.Visibility = Visibility.Visible;
                btnPersonalMedico.Visibility = Visibility.Visible;
                btnPersonalLaboratorio.Visibility = Visibility.Visible;
                btnCategorias.Visibility = Visibility.Visible;
                btnEspecialidades.Visibility = Visibility.Visible;
                btnPracticas.Visibility = Visibility.Visible;
                btnPracticasxIngreso.Visibility = Visibility.Visible;
                flagLaboratorio = false;
            }
            else
            {
                btnLocalidades.Visibility = Visibility.Hidden;
                btnPersonalMedico.Visibility = Visibility.Hidden;
                btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                btnCategorias.Visibility = Visibility.Hidden;
                btnEspecialidades.Visibility = Visibility.Hidden;
                btnPracticas.Visibility = Visibility.Hidden;
                btnPracticasxIngreso.Visibility = Visibility.Hidden;
                flagLaboratorio = true;
            }
        }
        public void ViewLocalidades()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Visible;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewMedicos()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Visible;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewPersonalLaboratorio()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Visible;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewCategorias()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Visible;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewEspecialidades()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Visible;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewPracticas()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Visible;
            GPracticasIngresos.Visibility = Visibility.Hidden;
        }
        public void ViewPracticasxIngreso()
        {
            GPacientes.Visibility = Visibility.Hidden;
            GIngresos.Visibility = Visibility.Hidden;
            GLocalidades.Visibility = Visibility.Hidden;
            GMedicos.Visibility = Visibility.Hidden;
            GpersonalLaboratorio.Visibility = Visibility.Hidden;
            GCategorias.Visibility = Visibility.Hidden;
            GEspecialidades.Visibility = Visibility.Hidden;
            GPracticas.Visibility = Visibility.Hidden;
            GPracticasIngresos.Visibility = Visibility.Visible;
        }
    }
}
