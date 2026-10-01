using ReflectionExamples.Models;

namespace ReflectionExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kus = new Bird();
            var dog = new Dog();

            if (kus is Bird)
            {
                Console.WriteLine("Evet, kuş bir kuştur.");
            }

            if (dog is Dog)
            {
                Console.WriteLine("Evet, köpek bir köpektir.");
            }

            if (kus is Dog)
            {
                Console.WriteLine("Evet, kuş bir köpektir.");
            }

            // GetType ve typeof

            if (kus.GetType() == typeof(Bird))
            {
                Console.WriteLine("Evet, kuş bir kuştur.");
            }

            if (dog.GetType() == typeof(Dog))
            {
                Console.WriteLine("Evet, köpek bir köpektir.");
            }

            Console.WriteLine(kus is Dog);
            Console.WriteLine(kus.GetType() == typeof(Dog));

            if (kus.GetType() == typeof(Dog))
            {
                Console.WriteLine("Evet, kuş bir köpektir.");
            }

            Console.WriteLine(kus.GetType().Name);

            Console.WriteLine(dog.GetType().Name);

            Bird kus1 = new Sparrow();

            Console.WriteLine(kus1.GetType() == typeof(Bird));

            Console.WriteLine(kus1.GetType().BaseType == typeof(Bird));

            kus1.Fly();

            // dotnet'de tip tipinde bir tip vardır.
            // Type -> aynı zamanda bir class tanımı
            // Runtime'da değişkenlerin tipleri ve o tiplerin özelliklerine erişmek için kullanılır

            Console.WriteLine(kus1.GetType().BaseType.Name);
        }
    }
}
