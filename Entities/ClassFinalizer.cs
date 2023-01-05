using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteBank.Entities
{
    public class ClassFinalizer
    {
        public void Finalizer()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Tecle Enter para voltar ao menu anterior");
            Console.ReadLine();
            Console.Clear();
        }
    }
}