using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactManager.Entities.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Company { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfileImage { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BirthDate { get; set; }

        public string PhonePersonal { get; set; }
        
        public string PhoneWork { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}
