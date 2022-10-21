using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FetchDataAPI.Data;
using FetchDataAPI.Models;

namespace FetchDataAPI.Controllers
{
    public class Logins1Controller : ApiController
    {
        private FetchDataAPIdbContext db = new FetchDataAPIdbContext();

        // GET: api/Logins1
        public IQueryable<Login> GetLogins()
        {
            return db.Logins;
        }

        // GET: api/Logins1/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult GetLogin(int id)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Logins1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogin(int id, Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.Id)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Logins1
        [ResponseType(typeof(Login))]
        public IHttpActionResult PostLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Logins.Add(login);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = login.Id }, login);
        }

        // DELETE: api/Logins1/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult DeleteLogin(int id)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            db.Logins.Remove(login);
            db.SaveChanges();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginExists(int id)
        {
            return db.Logins.Count(e => e.Id == id) > 0;
        }
    }
}