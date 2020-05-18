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

        [HttpPost]
        public IActionResult Post([FromBody] ContactViewModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repoContacts = new ContactsRepository(_context);
                    repoContacts.Create(contact);
                    return Created("newContact", contact);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var repoContacts = new ContactsRepository(_context);
                repoContacts.Update(contact);
                return Ok(contact);
            }
            return BadRequest(ModelState);
        }

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
