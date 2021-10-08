using System;
using Tema1.Domain;
using System.Collections.Generic;
using static Tema1.Domain.Cart;

namespace Tema1
{
    class Program
    {

        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfProducts = ReadListOfProducts().ToArray();
            UnvalidatedCart unvalidatedProducts = new(listOfProducts);
            ICart result = ValidateCart(unvalidatedProducts);
            result.Match(
                whenUnvalidatedCart: unvalidatedResult => unvalidatedProducts,
                whenEmptyCart: invalidResult => invalidResult,
                whenInvalidatedCart: invalidResult => invalidResult,
                whenValidatedCart: validatedResult => PaidCart(validatedResult),
                whenPaidCart: publishedResult => publishedResult
            );

            Console.WriteLine("Hello World!");
        }

        private static List<UnvalidatedProduct> ReadListOfProducts()
        {
            List<UnvalidatedProduct> listOfProducts = new();
            int maxProductNumber = 0;
            do
            {
                var productId = ReadValue("Product id: ");
                if (string.IsNullOrEmpty(productId))
                {
                    break;
                }

                var quantity = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                listOfProducts.Add(new(productId, quantity));
                ++maxProductNumber;
            } while (maxProductNumber != 5);

            var address = ReadValue("Address: ");

            Console.WriteLine("\nList of products: ");
            foreach(var product in listOfProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine(address);

            return listOfProducts;
        }




        private static ICart ValidateCart(UnvalidatedCart unvalidatedProducts) =>
            random.Next(100) > 50 ?
            new InvalidatedCart(new List<UnvalidatedProduct>(), "Random errror")
            : new ValidatedCart(new List<ValidatedProduct>());

        private static ICart PaidCart(ValidatedCart validCart) =>
            new PaidCart(new List<ValidatedProduct>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        
    }
}
