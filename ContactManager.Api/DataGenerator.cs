﻿using ContactManager.Data;
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
                                Company = "Springfield Nuclear Plant",
                                Email = "hsimpson@snp.com",
                                Name = "Simpson Homer",
                                PhonePersonal = "827364",
                                PhoneWork = "7895",
                                ProfileImage = "https://lh3.googleusercontent.com/proxy/QQcqti3zIpMN2sL47ZKfV1b8_Fk2oVwGdcImqdAMMTKj862qYu1rfQPzYtuivi53sUBoupNquFl_bNYoP5oRFzsNTcwTavGVQpMcsNfTdsiVYf-FmtQ",
                                Address = "742 Evergreen Terrace",
                                City = "Springfield"
                            },
                            new Contact
                            {
                                Id = 2,
                                BirthDate = new DateTime(1993, 1, 26),
                                Company = "Left Handled Market",
                                Email = "neddy@leftopia.ned",
                                Name = "Ned Flanders",
                                PhonePersonal = "666",
                                PhoneWork = "999",
                                ProfileImage = "https://vignette.wikia.nocookie.net/wikisimpsons2010/images/2/22/NED_FLANDERS_JR..png/revision/latest/scale-to-width-down/340?cb=20100929081708&path-prefix=es",
                                Address = "743 Evergreen Terrace",
                                City = "Springfield"
                            }
                            ,
                            new Contact
                            {
                                Id = 3,
                                BirthDate = new DateTime(1993, 1, 26),
                                Company = "School",
                                Email = "",
                                Name = "Groundskeeper Willy",
                                PhonePersonal = "567890",
                                PhoneWork = "098765",
                                ProfileImage = "https://upload.wikimedia.org/wikipedia/en/thumb/d/dc/GroundskeeperWillie.png/220px-GroundskeeperWillie.png",
                                Address = "741 Wood house",
                                City = "Kirkwall"
                            }
                                );

                context.SaveChanges();
            }
        }
    }
}