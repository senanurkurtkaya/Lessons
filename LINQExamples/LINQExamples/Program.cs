using LINQExamples.Models;

namespace LINQExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products =
            [
                new() { Id = 1, Name = "Laptop", SKU = "PRD001", Price = 35000, Stock = 10, IsActive = true, CreatedAt = new(2026, 1, 5), UpdatedAt = new(2026, 3, 12) },
                new() { Id = 2, Name = "Mouse", SKU = "PRD002", Price = 750, Stock = 50, IsActive = true, CreatedAt = new(2026, 1, 8), UpdatedAt = null },
                new() { Id = 3, Name = "Keyboard", SKU = "PRD003", Price = 1500, Stock = 30, IsActive = true, CreatedAt = new(2026, 1, 12), UpdatedAt = new(2026, 2, 20) },
                new() { Id = 4, Name = "Monitor", SKU = "PRD004", Price = 8500, Stock = 15, IsActive = true, CreatedAt = new(2026, 1, 15), UpdatedAt = null },
                new() { Id = 5, Name = "Headset", SKU = "PRD005", Price = 2200, Stock = 25, IsActive = true, CreatedAt = new(2026, 2, 1), UpdatedAt = new(2026, 4, 10) },
                new() { Id = 6, Name = "Webcam", SKU = "PRD006", Price = 1800, Stock = 20, IsActive = true, CreatedAt = new(2026, 2, 5), UpdatedAt = null },
                new() { Id = 7, Name = "Microphone", SKU = "PRD007", Price = 3200, Stock = 12, IsActive = true, CreatedAt = new(2026, 2, 10), UpdatedAt = new(2026, 5, 15) },
                new() { Id = 8, Name = "USB Hub", SKU = "PRD008", Price = 650, Stock = 40, IsActive = true, CreatedAt = new(2026, 2, 14), UpdatedAt = null },
                new() { Id = 9, Name = "SSD 1TB", SKU = "PRD009", Price = 2900, Stock = 35, IsActive = true, CreatedAt = new(2026, 3, 1), UpdatedAt = new(2026, 6, 8) },
                new() { Id = 10, Name = "RAM 16GB", SKU = "PRD010", Price = 1700, Stock = 45, IsActive = true, CreatedAt = new(2026, 3, 5), UpdatedAt = null },
                new() { Id = 11, Name = "Graphics Card", SKU = "PRD011", Price = 24000, Stock = 8, IsActive = true, CreatedAt = new(2026, 3, 10), UpdatedAt = new(2026, 7, 20) },
                new() { Id = 12, Name = "Processor", SKU = "PRD012", Price = 12500, Stock = 14, IsActive = true, CreatedAt = new(2026, 3, 15), UpdatedAt = null },
                new() { Id = 13, Name = "Motherboard", SKU = "PRD013", Price = 6800, Stock = 18, IsActive = true, CreatedAt = new(2026, 4, 1), UpdatedAt = new(2026, 6, 18) },
                new() { Id = 14, Name = "Power Supply", SKU = "PRD014", Price = 3500, Stock = 22, IsActive = true, CreatedAt = new(2026, 4, 5), UpdatedAt = null },
                new() { Id = 15, Name = "PC Case", SKU = "PRD015", Price = 2700, Stock = 16, IsActive = true, CreatedAt = new(2026, 4, 10), UpdatedAt = new(2026, 8, 1) },
                new() { Id = 16, Name = "CPU Cooler", SKU = "PRD016", Price = 1900, Stock = 28, IsActive = true, CreatedAt = new(2026, 4, 15), UpdatedAt = null },
                new() { Id = 17, Name = "External HDD", SKU = "PRD017", Price = 2400, Stock = 32, IsActive = true, CreatedAt = new(2026, 5, 1), UpdatedAt = new(2026, 7, 12) },
                new() { Id = 18, Name = "USB Flash Drive", SKU = "PRD018", Price = 450, Stock = 100, IsActive = true, CreatedAt = new(2026, 5, 5), UpdatedAt = null },
                new() { Id = 19, Name = "HDMI Cable", SKU = "PRD019", Price = 250, Stock = 80, IsActive = true, CreatedAt = new(2026, 5, 10), UpdatedAt = new(2026, 8, 15) },
                new() { Id = 20, Name = "Ethernet Cable", SKU = "PRD020", Price = 180, Stock = 120, IsActive = true, CreatedAt = new(2026, 5, 15), UpdatedAt = null },
                new() { Id = 21, Name = "WiFi Adapter", SKU = "PRD021", Price = 850, Stock = 25, IsActive = true, CreatedAt = new(2026, 6, 1), UpdatedAt = new(2026, 9, 5) },
                new() { Id = 22, Name = "Bluetooth Adapter", SKU = "PRD022", Price = 550, Stock = 42, IsActive = false, CreatedAt = new(2026, 6, 5), UpdatedAt = new(2026, 8, 20) },
                new() { Id = 23, Name = "Laptop Stand", SKU = "PRD023", Price = 1100, Stock = 25, IsActive = true, CreatedAt = new(2026, 6, 10), UpdatedAt = null },
                new() { Id = 24, Name = "Mouse Pad", SKU = "PRD024", Price = 350, Stock = 65, IsActive = true, CreatedAt = new(2026, 7, 1), UpdatedAt = new(2026, 9, 10) },
                new() { Id = 25, Name = "Desk Lamp", SKU = "PRD025", Price = 1350, Stock = 26, IsActive = false, CreatedAt = new(2026, 7, 15), UpdatedAt = null }
            ];
                       
            // First ilgili listedeki ilk elemanı alıp getirmeye çalışır, eğer ki liste boş ise InvalidOperationException throw eder.
            var firstProduct1 = products.First();
            // FirstOrDefault ilgili listedeki ilk elemanı alıp getirmeye çalışır, eğer ki liste boş ise ilgili listenin generic type argument'ının default değerini getirir. Reference typelar için bu değer null'dır, value typelar için değişkendir, örn; int -> 0, bool -> false, decimal -> 0.0.
            var firstProduct2 = products.FirstOrDefault();
            
            List<Product> emptyProducts = new List<Product>();

            try
            {
                var emptyProduct1 = emptyProducts.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var emptyProduct2 = emptyProducts.FirstOrDefault();

            List<int> numbers = new List<int>();

            try
            {
                var firstNumber1 = numbers.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            var firstNumber2 = numbers.FirstOrDefault();

            var lastProduct1 = products.Last();
            var lastProduct2 = products.LastOrDefault();

            // Products listesindeki Stock değeri 25'e eşit olan ilk product'ı getir.
            var firstProductWith25Stock = products.FirstOrDefault(product => product.Stock == 25);
            Console.WriteLine($"SKU: {firstProductWith25Stock?.SKU}, Name: {firstProductWith25Stock?.Name}");

            var lastProductWith25Stock = products.LastOrDefault(product => product.Stock == 25);
            Console.WriteLine($"SKU: {lastProductWith25Stock?.SKU}, Name: {lastProductWith25Stock?.Name}");

            // Single bir listedeki koşula uyan tekil elemanı alıp getirir, listede koşula uyan birden fazla varsa InvalidOperationException throw eder.
            var singleProductWith32Stock1 = products.Single(product => product.Stock == 32);
            var singleProductWith32Stock2 = products.SingleOrDefault(product => product.Stock == 32);

            try
            {
                var singleProductWith25Stock1 = products.Single(product => product.Stock == 25);
            }
            catch (Exception ex)
            {

            }            
        }
    }
}
