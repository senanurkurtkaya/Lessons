namespace ReflectionExamples.TypeExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            Type userType = user.GetType();

            Console.WriteLine($"Name: {userType.Name}"); // User -> doğru
            Console.WriteLine($"BaseTypeName: {userType.BaseType?.Name}"); // User // Object
            Console.WriteLine($"FullName: {userType.FullName}"); // ? // ReflectionExamples.TypeExamples.User
            Console.WriteLine($"Namespace: {userType.Namespace}"); // ReflectionExamples.TypeExamples -> doğru
            Console.WriteLine($"Assembly.FullName: {userType.Assembly.FullName}"); // Sürüm ve kimlik bilgileri // ReflectionExamples.TypeExamples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
            Console.WriteLine($"IsAbstract: {userType.IsAbstract}"); // Evet // False (Hayır)
            Console.WriteLine($"IsArray: {userType.IsArray}"); // Hayır -> doğru
            Console.WriteLine($"IsGenericType: {userType.IsGenericType}"); // Hayır -> doğru
            Console.WriteLine($"GenericTypeArguments: {userType.GenericTypeArguments.Count()}"); // Sıfır -> doğru

            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine();

            Repository<User> userRespository = new Repository<User>();

            Type userRepoType = userRespository.GetType();

            Console.WriteLine($"Name: {userRepoType.Name}");
            Console.WriteLine($"BaseTypeName: {userRepoType.BaseType?.Name}");
            Console.WriteLine($"FullName: {userRepoType.FullName}");
            Console.WriteLine($"Namespace: {userRepoType.Namespace}");
            Console.WriteLine($"Assembly.FullName: {userRepoType.Assembly.FullName}");
            Console.WriteLine($"IsAbstract: {userRepoType.IsAbstract}");
            Console.WriteLine($"IsArray: {userRepoType.IsArray}");
            Console.WriteLine($"IsGenericType: {userRepoType.IsGenericType}");
            Console.WriteLine($"GenericTypeArguments: {userRepoType.GenericTypeArguments.Count()}");
            Console.WriteLine($"AddMethodFirstParameterName: {userRepoType.GetMethod("Add")?.GetParameters().First().Name}");
        }
    }
}
