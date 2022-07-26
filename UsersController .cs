using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersSerrvice.Entities;
using UsersService.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersSerrvice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UsersController : ControllerBase
    {
        AppDbContext db;
        public UsersController()
        {
            db = new AppDbContext();
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return db.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return db.Users.Where(x => x.Id == id).SingleOrDefault();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Users user)
        {
            try
            {
                Users u = db.Users.Where(x => x.Id == user.Id).SingleOrDefault();
                if (u != null)
                {
                    u.Name = user.Name;
                    u.Address = user.Address;
                    u.Contact = user.Contact;
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Users u = db.Users.Where(x => x.Id == id).SingleOrDefault();
                if (u != null)
                {
                    db.Users.Remove(u);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}


