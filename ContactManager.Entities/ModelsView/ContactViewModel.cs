using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Entities.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Company { get; set; }

        public string ProfileImage { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PhonePersonal { get; set; }
        
        public string PhoneWork { get; set; }

    }
}
