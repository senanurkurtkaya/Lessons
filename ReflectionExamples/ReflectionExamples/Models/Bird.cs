namespace ReflectionExamples.Models
{
    internal class Bird : Animal
    {
        public int WingLength { get; set; }

        public int Fly()
        {
            return 5;
        }
    }
}
