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
using ApiPrueba.Models;

namespace ApiPrueba.Controllers
{
    public class DistributorsController : ApiController
    {
        private vgdEntities db = new vgdEntities();

        // GET: api/Distributors
        public IQueryable<Distributors> GetDistributors()
        {
            return db.Distributors;
        }

        // GET: api/Distributors/5
        [ResponseType(typeof(Distributors))]
        public IHttpActionResult GetDistributors(string id)
        {
            Distributors distributors = db.Distributors.Find(id);
            if (distributors == null)
            {
                return NotFound();
            }

            return Ok(distributors);
        }

        // PUT: api/Distributors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistributors(string id, Distributors distributors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distributors.Id)
            {
                return BadRequest();
            }

            db.Entry(distributors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributorsExists(id))
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

        // POST: api/Distributors
        [ResponseType(typeof(Distributors))]
        public IHttpActionResult PostDistributors(Distributors distributors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distributors.Add(distributors);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DistributorsExists(distributors.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = distributors.Id }, distributors);
        }

        // DELETE: api/Distributors/5
        [ResponseType(typeof(Distributors))]
        public IHttpActionResult DeleteDistributors(string id)
        {
            Distributors distributors = db.Distributors.Find(id);
            if (distributors == null)
            {
                return NotFound();
            }

            db.Distributors.Remove(distributors);
            db.SaveChanges();

            return Ok(distributors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistributorsExists(string id)
        {
            return db.Distributors.Count(e => e.Id == id) > 0;
        }
    }
}