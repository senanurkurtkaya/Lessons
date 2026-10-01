using EFCoreValueConverters.Enums;

namespace EFCoreValueConverters.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserState State { get; set; }
    }
}
