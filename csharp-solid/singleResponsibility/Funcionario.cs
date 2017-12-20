namespace csharp_solid
{
    public class Funcionario
    {
        public Cargo Cargo { get; set; }
        public double SalarioBase { get; set; }

        public Funcionario(Cargo cargo, double valor)
        {
            this.Cargo = cargo;
            this.SalarioBase = valor;
        }

        public double CalculaSalario()
        {
            return this.Cargo.Regra.Calcula(this);
        }
    }
}