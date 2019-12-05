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
        private VideoGamesDatabaseEntities db = new VideoGamesDatabaseEntities();

        // GET: api/Distributors
        public IQueryable<Distributor> GetDistributor()
        {
            return db.Distributor;
        }

        // GET: api/Distributors/5
        [ResponseType(typeof(Distributor))]
        public IHttpActionResult GetDistributor(string id)
        {
            Distributor distributor = db.Distributor.Find(id);
            if (distributor == null)
            {
                return NotFound();
            }

            return Ok(distributor);
        }

        // PUT: api/Distributors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistributor(string id, Distributor distributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distributor.Id)
            {
                return BadRequest();
            }

            db.Entry(distributor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributorExists(id))
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
        [ResponseType(typeof(Distributor))]
        public IHttpActionResult PostDistributor(Distributor distributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distributor.Add(distributor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DistributorExists(distributor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = distributor.Id }, distributor);
        }

        // DELETE: api/Distributors/5
        [ResponseType(typeof(Distributor))]
        public IHttpActionResult DeleteDistributor(string id)
        {
            Distributor distributor = db.Distributor.Find(id);
            if (distributor == null)
            {
                return NotFound();
            }

            db.Distributor.Remove(distributor);
            db.SaveChanges();

            return Ok(distributor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistributorExists(string id)
        {
            return db.Distributor.Count(e => e.Id == id) > 0;
        }
    }
}