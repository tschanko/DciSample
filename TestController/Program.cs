using System;
using Domain.Model;
using Domain.UseCases;
using Domain.UseCases.TransferMoneyBasic;

namespace TestController {
    class Program {
        static void Main(string[] args) {
            var source = new SavingsAccount();
            var sink = new SavingsAccount();

            Console.WriteLine("Before:");
            Console.WriteLine($"Source: {source}");
            Console.WriteLine($"Sink: {sink}");

            Console.WriteLine("Run transfer:");

            new TransferMoneyContext(source, sink, 1000).DoIt();

            Console.WriteLine("After:");
            Console.WriteLine($"Source: {source}");
            Console.WriteLine($"Sink: {sink}");

            Console.ReadLine();
        }
    }
}