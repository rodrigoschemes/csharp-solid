namespace csharp_solid
{
    public class Pagamento
    {
        public double Valor { get; set; }
        public MeioDePagamento Boleto;

        public Pagamento(double valor, MeioDePagamento boleto)
        {
            this.Valor = valor;
            this.Boleto = boleto;
        }
    }
}