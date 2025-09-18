using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionFlota
{
    public partial class Form1 : Form
    {
        private List<Vehiculo> flota;

        public Form1()
        {
            InitializeComponent();
            flota = new List<Vehiculo>();
            CargarDatosPrueba();
            RefrescarTabla();
        }

        private void CargarDatosPrueba()
        {
            flota.Add(new Auto("Toyota", "Corolla", 2020, 20000m, 4));
            flota.Add(new Moto("Yamaha", "R3", 2021, 10000m, 300));
            flota.Add(new Camion("Volvo", "FH16", 2019, 80000m, 20));
            flota.Add(new AutoHibrido("Toyota", "Prius", 2022, 25000m, 4));
        }

        private void RefrescarTabla()
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = flota.Select(v => new
            {
                Tipo = v.GetType().Name,
                v.Marca,
                v.Modelo,
                v.Anio,
                v.CostoBase,
                Impuesto = v.CalcularImpuesto(),
                Mantenimiento = v.CalcularCostoMantenimiento()
            }).ToList();
        }
    }
}
