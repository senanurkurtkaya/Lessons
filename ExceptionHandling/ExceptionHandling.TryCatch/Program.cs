using System.Text;

namespace ExceptionHandling.TryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                // catch içerisinde sadece throw dersek, gelen exception'ı alıp olduğu gibi fırlatır ve StackTrace değişmez.
                // throw;

                // catch içerisinde throw new Exception dersek, yakalanan exception'ı yutar, ve yeni exception'a göre farklı bir StackTrace ve mesaj oluşur.
                // throw new Exception("Hata oluştu, mesajı değiştirdik");

                // catch içerisinde throw new Exception diyip, 2. parametre olarak (inner exception) yakalanan exception'ı verirsek, hem yakalanan exception'ın mesajı ve StackTrace'i hem de yeni throw ettiğimiz exception'ın mesajı ve StackTrace'i beraber gösterilir.
                throw new Exception("3. parti bir uygulamada hata oluştu.", ex);
            }

            Console.WriteLine("Hello, World!");
        }

        public static void Run()
        {
            throw new Exception("Hata oluştu.");
        }
    }
}
