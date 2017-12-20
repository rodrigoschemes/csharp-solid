using System;

namespace csharp_solid
{
    public class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Salvando nota...");
        }
    }
}