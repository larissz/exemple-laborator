using System;
using System.Text.RegularExpressions;

namespace Tema1.Domain
{
    public record ProductId
    {
        private static readonly Regex ValidPattern = new("^[0-9]{4}$");

        public string Value { get; }

        private ProductId(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductIdException("");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
