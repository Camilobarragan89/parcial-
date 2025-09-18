using System;

namespace GestionFlota
{
    public interface IMantenible
    {
        decimal CalcularCostoMantenimiento();
    }

    public interface IElectrico
    {
        void CargarBateria();
    }

    public interface ICombustion
    {
        void LlenarTanque();
    }

    public abstract class Vehiculo : IMantenible
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal CostoBase { get; set; }

        public Vehiculo(string marca, string modelo, int anio, decimal costoBase)
        {
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            CostoBase = costoBase;
        }

        public abstract decimal CalcularImpuesto();
        public abstract decimal CalcularCostoMantenimiento();
    }

    public class Auto : Vehiculo
    {
        public int NumPuertas { get; set; }
        public Auto(string marca, string modelo, int anio, decimal costoBase, int numPuertas)
            : base(marca, modelo, anio, costoBase)
        {
            NumPuertas = numPuertas;
        }
        public override decimal CalcularImpuesto() => CostoBase * 0.10m;
        public override decimal CalcularCostoMantenimiento() => 500m;
    }

    public class Moto : Vehiculo
    {
        public int Cilindrada { get; set; }
        public Moto(string marca, string modelo, int anio, decimal costoBase, int cilindrada)
            : base(marca, modelo, anio, costoBase)
        {
            Cilindrada = cilindrada;
        }
        public override decimal CalcularImpuesto() => CostoBase * 0.05m;
        public override decimal CalcularCostoMantenimiento() => 200m;
    }

    public class Camion : Vehiculo
    {
        public double CapacidadCarga { get; set; }
        public Camion(string marca, string modelo, int anio, decimal costoBase, double capacidadCarga)
            : base(marca, modelo, anio, costoBase)
        {
            CapacidadCarga = capacidadCarga;
        }
        public override decimal CalcularImpuesto() => CostoBase * 0.15m;
        public override decimal CalcularCostoMantenimiento() => 1000m;
    }

    public class AutoHibrido : Auto, IElectrico, ICombustion
    {
        public AutoHibrido(string marca, string modelo, int anio, decimal costoBase, int numPuertas)
            : base(marca, modelo, anio, costoBase, numPuertas) { }

        public override decimal CalcularImpuesto() => CostoBase * 0.12m;
        public override decimal CalcularCostoMantenimiento() => 700m;

        public void CargarBateria() { }
        public void LlenarTanque() { }
    }
}
