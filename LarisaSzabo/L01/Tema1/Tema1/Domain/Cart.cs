using CSharp.Choices;
using System;
using System.Collections.Generic;

namespace Tema1.Domain
{
    [AsChoice]
    public static partial class Cart
    {
        public interface ICart { }

        public record UnvalidatedCart(IReadOnlyCollection<UnvalidatedProduct> ProductsList) : ICart;

        //ar trebuie sa fie gol
        public record EmptyCart() : ICart;

        //mai trebuie adaugata starea de invalid
        public record InvalidatedCart(IReadOnlyCollection<UnvalidatedProduct> ProductsList, string reason) : ICart;

        public record ValidatedCart(IReadOnlyCollection<ValidatedProduct> ProductsList) : ICart;

        public record PaidCart(IReadOnlyCollection<ValidatedProduct> ProductsList, DateTime PublishedDate) : ICart;
    }
}