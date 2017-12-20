using System;

namespace csharp_solid
{
    public class Frete : IServicoDeEntrega
    {

        public double Para(string cidade)
        {
            if ("SAO PAULO".Equals(cidade.ToUpper()))
            {
                return 15;
            }
            return 30;
        }
    }
}