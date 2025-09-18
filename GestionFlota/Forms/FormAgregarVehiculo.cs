using System;
using System.Windows.Forms;

namespace GestionFlota
{
    public partial class FormAgregarVehiculo : Form
    {
        public Vehiculo NuevoVehiculo { get; private set; }

        public FormAgregarVehiculo()
        {
            InitializeComponent();
            cboTipo.Items.AddRange(new string[] { "Auto", "Moto", "Camion", "AutoHibrido" });
            cboTipo.SelectedIndex = 0;
        }
    }
}
