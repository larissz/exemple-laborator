using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Tema1.Domain
{
    public record Address
    {
        private static readonly Regex ValidPattern = new("^[a-zA-Z0-9.,]$");

        //public string Value { get; }
        public string Oras { get; }
        public string Strada { get; }
        public string Judet { get; }
        public string CodPostal { get; }


        public Address(string oras, string strada, string judet, string codpostal)
        {
            if (ValidPattern.IsMatch(oras))
            {
                Oras = oras;
                Strada = strada;
                Judet = judet;
                CodPostal = codpostal;
            }
            else
            {
                throw new InvalidAddressException("");
            }
        }
        public override string ToString()
        {
            return Oras.ToString();
            return Strada.ToString();
            return Judet.ToString();
            return CodPostal.ToString();
        }
    }
}
