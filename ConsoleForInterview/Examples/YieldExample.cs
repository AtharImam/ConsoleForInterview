using System;
using System.Collections.Generic;

namespace ConsoleForInterview
{
    public class YieldExample
    {
        public static void Execute()
        {
            var obj = new YieldExample();
            Console.WriteLine(obj);
            var invoices = GetInvoices();
            DoubleAmounts(invoices);
        }

        public static void DoubleAmounts(IEnumerable<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                invoice.Amount = invoice.Amount * 2;
                Console.WriteLine("DoubleAmounts: " + invoice);
            }
        }

        public static IEnumerable<Invoice> GetInvoices()
        {
            for(int index = 0; index < 5; index++)
            {
                Invoice inv = new Invoice { Id = index + 1, Amount = (index + 1) * 1000 };
                Console.WriteLine("GetInvoices: " + inv);
                yield return inv;
            }
        }

        public class Invoice
        {
            public int Id { get; set; }

            public double Amount { get; set; }

            public override string ToString()
            {
                return $"Id :{Id}, Amount: {Amount}";
            }
        }

        public static IEnumerable<int> GetNumber()
        {
            for(int index = 0; index < 5; index++)
            {
                yield return (index + 1)*10;
                int num = 10;
            }
        }
    }
}
