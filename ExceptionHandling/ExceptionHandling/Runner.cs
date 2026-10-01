using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Runner
    {
        public static void AnotherRun()
        {
            LastRun();
        }

        public static void LastRun()
        {
            throw new Exception("Hata oluştu.");
        }
    }
}
