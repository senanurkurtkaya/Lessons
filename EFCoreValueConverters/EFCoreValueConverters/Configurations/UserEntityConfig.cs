using EFCoreValueConverters.Enums;
using EFCoreValueConverters.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreValueConverters.Configurations
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            /*
             * select * from Users

            -- trade-off
            -- int -> State -> querylerde state'e göre sorgu yapmak daha hızlı olur
            -- nvarchar -> State -> querylerde performans kaybına sebep olabilir
             */

            builder.Property(x => x.State)
                .HasConversion(
                    userStateToDb => userStateToDb.ToString(),
                    userStateFromDb => Enum.Parse<UserState>(userStateFromDb)
                );
        }
    }
}
