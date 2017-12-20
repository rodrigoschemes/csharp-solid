using System;
using System.Collections.Generic;

namespace csharp_solid
{
    public class Fatura
    {
        public string Nome { get; set; }
        public double ValorMensal { get; private set; }
        public IList<Pagamento> Pagamentos;
        public double Valor { get; private set; }
        public bool Pago { get; private set; }

        public Fatura(string nome, double valorMensal)
        {
            this.Nome = nome;
            this.ValorMensal = valorMensal;
            this.Pagamentos = new List<Pagamento>();
            this.Pago = false;
        }

        public void AdicionaPagamento(Pagamento pagto)
        {
            this.Pagamentos.Add(pagto);

            if (this.ValorTotalDosPagamentos() >= this.ValorMensal)
            {
                this.Pago = true;
            }
        }

        private double ValorTotalDosPagamentos()
        {
            double total = 0;

            foreach (Pagamento pag in Pagamentos)
            {
                total += pag.Valor;
            }

            return total;
        }
    }
}