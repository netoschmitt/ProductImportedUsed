using System;
using ProductImportedUsed.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace ProductImportedUsed
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListaProdutos = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
               
                if (type == 'c')
                {
                    ListaProdutos.Add(new Product(name, price));
                }
                else if (type == 'u')
                {
                    Console.Write("Manufacture Date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    ListaProdutos.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    ListaProdutos.Add(new ImportedProduct(name, price, customsFee));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product product in ListaProdutos)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}
