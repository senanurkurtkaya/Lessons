using System.Text;

namespace ExceptionHandling
{
    internal class Program
    {
        // Exception -> istisnai durumlar

        // Exception StackTrace örneği;
        /*
         * Unhandled exception. System.Exception: Hata oluştu.
        at ExceptionHandling.Runner.LastRun() in C:\Projects\Lessons\ExceptionHandling\ExceptionHandling\Runner.cs:line 16
        at ExceptionHandling.Runner.AnotherRun() in C:\Projects\Lessons\ExceptionHandling\ExceptionHandling\Runner.cs:line 11
        at ExceptionHandling.Program.Run() in C:\Projects\Lessons\ExceptionHandling\ExceptionHandling\Program.cs:line 18
        at ExceptionHandling.Program.Main(String[] args) in C:\Projects\Lessons\ExceptionHandling\ExceptionHandling\Program.cs:line 11
        */

        static void Main(string[] args)
        {
            Run();

            Console.WriteLine("Hello, World!");
        }

        public static void Run()
        {
            Runner.AnotherRun();
        }
    }
}
