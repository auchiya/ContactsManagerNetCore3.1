using ContactManager.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManager.Data.Repositories
{
    public class ContactsRepository
    {
        private ContactsDbContext _context;

        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactViewModel> Get()
        {
            try
            {
                var viewModels = new List<ContactViewModel>();
                var contacts = _context.Contacts.ToList();
                foreach (var item in contacts)
                    viewModels.Add(ContactToViewModel(item));

                return viewModels;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ContactViewModel Get(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact is null) return null;

            return ContactToViewModel(contact);
        }

        public ContactViewModel Create(ContactViewModel contact)
        {
            var contactModel = ContactToModel(contact);
            _context.Contacts.Add(contactModel);
            _context.SaveChanges();
            return ContactToViewModel(contactModel);
        }

        public ContactViewModel Update(ContactViewModel contact)
        {
            var contactModel = ContactToModel(contact);
            _context.Contacts.Update(contactModel);
            _context.SaveChanges();
            return ContactToViewModel(contactModel);
        }

        public void Delete(int id)
        {
            var contactModel = _context.Contacts.Find(id);
            _context.Contacts.Remove(contactModel);
            _context.SaveChanges();
        }

        public ContactViewModel ContactToViewModel(Contact contact)
        {
            var viewModel = new ContactViewModel();
            viewModel.BirthDate = contact.BirthDate;
            viewModel.Company = contact.Company;
            viewModel.Email = contact.Email;
            viewModel.Id = contact.Id;
            viewModel.Name = contact.Name;
            viewModel.PhonePersonal = contact.PhonePersonal;
            viewModel.PhoneWork = contact.PhoneWork;
            viewModel.ProfileImage = contact.ProfileImage;
            
            return viewModel;
        }

        public Contact ContactToModel(ContactViewModel contact)
        {
            var model = new Contact();
            model.BirthDate = contact.BirthDate;
            model.Company = contact.Company;
            model.Email = contact.Email;
            model.Id = contact.Id;
            model.Name = contact.Name;
            model.PhonePersonal = contact.PhonePersonal;
            model.PhoneWork = contact.PhoneWork;
            model.ProfileImage = contact.ProfileImage;

            return model;
        }

        
    }
}
