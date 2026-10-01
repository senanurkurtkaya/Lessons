namespace ExceptionHandling.MultipleCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception? kontrol = null;

            do
            {
                try
                {
                    kontrol = null;

                    Console.WriteLine("Birinci sayıyı giriniz:");

                    var sayi1Text = Console.ReadLine();

                    int sayi1 = int.Parse(string.IsNullOrEmpty(sayi1Text) ? null : sayi1Text);

                    Console.WriteLine("İkinci sayıyı giriniz:");

                    var sayi2Text = Console.ReadLine();

                    int sayi2 = int.Parse(string.IsNullOrEmpty(sayi2Text) ? null : sayi2Text);

                    int sonuc = sayi1 / sayi2;

                    Console.WriteLine($"Sonuç: {sonuc}");
                }
                catch (FormatException formatException)
                {
                    kontrol = formatException;
                    Console.WriteLine("Yanlış formatta veri girdiniz, tekrar deneyiniz.");
                }
                catch (ArgumentNullException argException)
                {
                    kontrol = argException;
                    Console.WriteLine("Hiçbir değer girmediniz, tekrar deneyiniz.");
                }
                catch (Exception ex) when (ex is DivideByZeroException)
                {
                    kontrol = ex;
                    Console.WriteLine("Sıfıra bölünmeye çalışıldı.");
                }
                catch (Exception ex) when (ex.Message != null)
                {
                    kontrol = ex;
                    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                }
                catch (Exception ex)
                {
                    kontrol = ex;
                    Console.WriteLine("Beklenmedik bir hata oluştu.");
                }

            } while (kontrol != null);
        }
    }
}
