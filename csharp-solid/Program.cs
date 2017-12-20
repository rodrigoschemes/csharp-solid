using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Encapsulamento();
        }

        private static void Encapsulamento()
        {
            IList<Boleto> boletos = new List<Boleto>();

            boletos.Add(new Boleto(500));
            boletos.Add(new Boleto(500));
            boletos.Add(new Boleto(500));
            boletos.Add(new Boleto(500));

            Fatura fatura = new Fatura("Caelum", 2000);

            ProcessadorDeBoletos pdb = new ProcessadorDeBoletos();
            pdb.Processa(boletos, fatura);

            Console.WriteLine(fatura.Pago);
            Console.ReadKey();
        }

        /// <summary>
        /// O: Open/Closed principle - software entities should be open for extension, but closed for modification
        /// </summary>
        private static void OpenClosed()
        {
            Compra compra = new Compra(500, "São Paulo");
            CalculadoraDePrecos calcFrete = new CalculadoraDePrecos(new TabelaDePrecoPadrao(), new Frete());
            CalculadoraDePrecos calcTrans = new CalculadoraDePrecos(new TabelaDePrecoPadrao(), new Transportadora());

            double resultado = calcFrete.Calcula(compra);
            Console.WriteLine($"O preço da compra com frete correio: {resultado}");

            double resultadoTrans = calcTrans.Calcula(compra);
            Console.WriteLine($"O preço da compra com frete transportadora: {resultadoTrans}");

            Console.ReadKey();
        }

        /// <summary>
        /// D: Dependency inversion principle - one should “depend upon abstractions, [not] concretions
        /// </summary>
        private static void DependencyInversion()
        {
            IAcaoAposGerarNota enviarEmail = new EnviadorDeEmail();
            IAcaoAposGerarNota notaFiscal = new NotaFiscalDao();

            IList<IAcaoAposGerarNota> acoes = new List<IAcaoAposGerarNota>();
            acoes.Add(enviarEmail);
            acoes.Add(notaFiscal);

            GeradorDeNotaFiscal nf = new GeradorDeNotaFiscal(acoes);
            Fatura fatura = new Fatura("Rodrigo", 200);

            nf.Gera(fatura);

            Console.ReadKey();
        }

        /// <summary>
        /// S: Single responsibility principle - A class should have only a single responsibility
        /// </summary>
        private static void SingleResponsibility()
        {
            CalculadoraDeSalario cs = new CalculadoraDeSalario();
            Funcionario funcionario = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);
            double resultado;

            resultado = cs.Calcula(funcionario);

            Console.WriteLine($"O salário líquido de um dev que ganha R$2000 é: {resultado}");
            Console.ReadKey();
        }
    }
}
