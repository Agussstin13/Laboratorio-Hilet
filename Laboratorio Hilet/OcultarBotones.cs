using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Laboratorio_Hilet
{
    partial class MainWindow
    {
        bool banderaingreso = false;
        void Verbotones()
        {
            btnAgregar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Hidden;
            DeshabilitarIngreso();
            HabilitarCambio();
            banderaingreso = false;
        }
        void Verbotones(Button b)
        {
            btnAgregar.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Hidden;
            btnEliminar.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            HabilitarIngreso();
            DeshabilitarCambio();
            banderaingreso = true;
        }
        void HabilitarIngreso()
        {
            switch (selectedview)
            {
                case 1:
                    GPacientes2.Visibility = Visibility.Visible;
                    break;
                case 2:
                    GIngresos2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    GLocalidades2.Visibility = Visibility.Visible;
                    break;
                case 4:
                    GMedicos2.Visibility = Visibility.Visible;
                    break;
                case 5:
                    GpersonalLaboratorio2.Visibility = Visibility.Visible;
                    break;
                case 6:
                    GCategorias2.Visibility = Visibility.Visible;
                    break;
                case 7:
                    GEspecialidades2.Visibility = Visibility.Visible;
                    break;
                case 8:
                    GPracticas2.Visibility = Visibility.Visible;
                    break;
                case 9:
                    GPracticasIngresos2.Visibility = Visibility.Visible;
                    break;
            }
        }
        void DeshabilitarIngreso()
        {
            switch (selectedview)
            {
                case 1:
                    GPacientes2.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    GIngresos2.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    GLocalidades2.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    GMedicos2.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    GpersonalLaboratorio2.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    GCategorias2.Visibility = Visibility.Hidden;
                    break;
                case 7:
                    GEspecialidades2.Visibility = Visibility.Hidden;
                    break;
                case 8:
                    GPracticas2.Visibility = Visibility.Hidden;
                    break;
                case 9:
                    GPracticasIngresos2.Visibility = Visibility.Hidden;
                    break;
                default:
                    GPacientes2.Visibility = Visibility.Hidden;
                    GIngresos2.Visibility = Visibility.Hidden;
                    GLocalidades2.Visibility = Visibility.Hidden;
                    GMedicos2.Visibility = Visibility.Hidden;
                    GpersonalLaboratorio2.Visibility = Visibility.Hidden;
                    GCategorias2.Visibility = Visibility.Hidden;
                    GEspecialidades2.Visibility = Visibility.Hidden;
                    GPracticas2.Visibility = Visibility.Hidden;
                    GPracticasIngresos2.Visibility = Visibility.Hidden;
                    break;
            }
        }
        void HabilitarCambio()
        {
            btnpacientes.Visibility = Visibility.Visible;
            btningresos.Visibility = Visibility.Visible;
            btnLocalidades.Visibility = Visibility.Visible;
            btnLaboratorio.Visibility = Visibility.Visible;
            btnPersonalMedico.Visibility = Visibility.Visible;
            btnPersonalLaboratorio.Visibility = Visibility.Visible;
            btnCategorias.Visibility = Visibility.Visible;
            btnEspecialidades.Visibility = Visibility.Visible;
            btnPracticas.Visibility = Visibility.Visible;
            btnPracticasxIngreso.Visibility = Visibility.Visible;
        }
        void DeshabilitarCambio()
        {
            switch (selectedview)
            {
                case 1:
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 7:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 8:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticasxIngreso.Visibility = Visibility.Hidden;
                    break;
                case 9:
                    btnpacientes.Visibility = Visibility.Hidden;
                    btningresos.Visibility = Visibility.Hidden;
                    btnLocalidades.Visibility = Visibility.Hidden;
                    btnLaboratorio.Visibility = Visibility.Hidden;
                    btnPersonalMedico.Visibility = Visibility.Hidden;
                    btnPersonalLaboratorio.Visibility = Visibility.Hidden;
                    btnCategorias.Visibility = Visibility.Hidden;
                    btnEspecialidades.Visibility = Visibility.Hidden;
                    btnPracticas.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
