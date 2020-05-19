using ContactManager.Data;
using ContactManager.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Api
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContactsDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ContactsDbContext>>()))
            {
                if (context.Contacts.Any())
                {
                    return;
                }

                context.Contacts.AddRange(
                                new Contact
                                {
                                    Id = 1,
                                    BirthDate = new DateTime(1993, 1, 26),
                                    Company = "KIN+CARTA",
                                    Email = "uchiya.agustin@gmail.com",
                                    Name = "Uchiya Agustin",
                                    PhonePersonal = "+5491127185267",
                                    PhoneWork = "46641811",
                                    ProfileImage = "https://lh3.googleusercontent.com/proxy/ZYI1KIDaJA5gsjivyK1vp7WXCclQftlQiTvTQ5-5jWcFWx1nsdIThsKsEO-ZtksOHtSTSL9Utj8JI17p7GRsxNAJqr0EhkuicZUOWMM5nrZObnWKWSMgLpjoJLLlE9n5",
                                    Address = "742 Evergreen Terrace",
                                    City = "Springfield"
                                },
                                new Contact
                                {
                                    Id = 2,
                                    BirthDate = new DateTime(1993, 1, 26),
                                    Company = "SONY",
                                    Email = "support@sony.jp",
                                    Name = "Miyamoto Musashi",
                                    PhonePersonal = "666",
                                    PhoneWork = "999",
                                    ProfileImage = "https://khronoshistoria.com/wp-content/uploads/2020/02/Miyamoto-Musashi.png",
                                    Address = "743 Evergreen Terrace",
                                    City = "Springfield"
                                }
                                );

                context.SaveChanges();
            }
        }
    }
}