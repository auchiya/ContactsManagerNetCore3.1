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

        public IEnumerable<ContactViewModel> Search(string email, string phone)
        {
            try
            {
                var searchByEmail = !string.IsNullOrWhiteSpace(email);
                var searchByPhone = !string.IsNullOrWhiteSpace(phone);

                var contacts = _context.Contacts.Where(c => (searchByEmail ? c.Email.ToUpper().Contains(email.ToUpper()) : true)
                                                            && ((searchByPhone ? c.PhonePersonal.ToUpper().Contains(phone.ToUpper()) : true)
                                                                || (searchByPhone ? c.PhoneWork.ToUpper().Contains(phone.ToUpper()) : true))
                                                      ).ToList();
                
                var searchResults = new List<ContactViewModel>();
                
                foreach (var item in contacts)
                    searchResults.Add(ContactToViewModel(item));

                return searchResults;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<ContactViewModel> Search(string city)
        {
            try
            {
                var searchByCity = !string.IsNullOrWhiteSpace(city);

                var contacts = _context.Contacts.Where(c => (searchByCity ? c.City.ToUpper().Equals(city.ToUpper()) : true)
                                                      ).ToList();

                var searchResults = new List<ContactViewModel>();

                foreach (var item in contacts)
                    searchResults.Add(ContactToViewModel(item));

                return searchResults;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            viewModel.City = contact.City;
            viewModel.Address = contact.Address;

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
            model.City = contact.City;
            model.Address = contact.Address;
            return model;
        }

        
    }
}
