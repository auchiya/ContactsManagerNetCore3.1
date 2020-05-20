using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Data;
using ContactManager.Data.Repositories;
using ContactManager.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private ContactsDbContext _context;

        public ContactsController(ContactsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list with al the contacts
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var repoContacts = new ContactsRepository(_context);
                var contacts = repoContacts.Get();
                return Ok(contacts);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get a specific contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The contact searched</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var repoContacts = new ContactsRepository(_context);
                var contact = repoContacts.Get(id);
                if (contact is null)
                    return NotFound();
                return Ok(contact);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Search in all the contacts by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>A list of contacts that matches with the city</returns>
        [HttpGet("city")]
        public IActionResult Search([FromQuery] string city)
        {
            try
            {
                var repoContacts = new ContactsRepository(_context);
                var searchResult = repoContacts.Search(city);
                if (searchResult.Any())
                    return Ok(searchResult);

                return NotFound();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Search in all the contacts by email or phone
        /// </summary>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns>A list of contacts that matches with the search params</returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string email, [FromQuery] string phone)
        {
            try
            {
                var repoContacts = new ContactsRepository(_context);
                var searchResult = repoContacts.Search(email, phone);
                if (searchResult.Any())
                    return Ok(searchResult);

                return NotFound();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new contact
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "Id":0,
        ///        "Name":"Montgomery Burns",
        ///        "Company":"Springfield Nuclear Plant",
        ///        "ProfileImage":"Base64String Image or Image Url",
        ///        "Email":"burns@excelent.com",
        ///        "BirthDate":"1712-01-02",
        ///        "PhonePersonal":"666",
        ///        "PhoneWork":"666666",
        ///        "address": "666 Nuclear Plant",
        ///        "city": "Spingfield"
        ///     }
        ///
        /// </remarks>
        /// <param name="contact"></param>
        /// <returns>The contact created</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ContactViewModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repoContacts = new ContactsRepository(_context);
                    var createdContact = repoContacts.Create(contact);
                    return Created("newContact", createdContact);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates contact information
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /
        ///     {
        ///        "Id":4,
        ///        "Name":"Montgomery Burns",
        ///        "Company":"Springfield Nuclear Plant",
        ///        "ProfileImage":"Base64String Image or Image Url",
        ///        "Email":"montgomery@burns.com",
        ///        "BirthDate":"1705-01-02",
        ///        "PhonePersonal":"777",
        ///        "PhoneWork":"7777",
        ///        "address": "999 Nuclear Plant",
        ///        "city": "Spingfield West"
        ///     }
        ///
        /// </remarks>
        /// <param name="contact"></param>
        /// <returns>The contact updated</returns>
        [HttpPut]
        public IActionResult Put([FromBody] ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var repoContacts = new ContactsRepository(_context);
                repoContacts.Update(contact);
                return Ok(contact);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete a contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode 200</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var repoContacts = new ContactsRepository(_context);
                repoContacts.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
