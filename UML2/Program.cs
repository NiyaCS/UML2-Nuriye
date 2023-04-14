using System;
using static System.Formats.Asn1.AsnWriter;

namespace UML2
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Test();
            Console.Write("Tryk på en knap for at åbne user dialog'en");
            Console.ReadKey();
            store.Run();
        }
    }
}
