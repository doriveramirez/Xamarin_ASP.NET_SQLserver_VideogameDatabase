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
using MVCCrudAPI.Models;

namespace MVCCrudAPI.Controllers
{
    public class BicyclesController : ApiController
    {
        private bicyclesEntities1 db = new bicyclesEntities1();

        // GET: api/Bicycles
        public IQueryable<Bicycles> GetBicycles()
        {
            return db.Bicycles;
        }

        // GET: api/Bicycles/5
        [ResponseType(typeof(Bicycles))]
        public IHttpActionResult GetBicycles(int id)
        {
            Bicycles bicycles = db.Bicycles.Find(id);
            if (bicycles == null)
            {
                return NotFound();
            }

            return Ok(bicycles);
        }

        // PUT: api/Bicycles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBicycles(int id, Bicycles bicycles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bicycles.ID)
            {
                return BadRequest();
            }

            db.Entry(bicycles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicyclesExists(id))
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

        // POST: api/Bicycles
        [ResponseType(typeof(Bicycles))]
        public IHttpActionResult PostBicycles(Bicycles bicycles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bicycles.Add(bicycles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bicycles.ID }, bicycles);
        }

        // DELETE: api/Bicycles/5
        [ResponseType(typeof(Bicycles))]
        public IHttpActionResult DeleteBicycles(int id)
        {
            Bicycles bicycles = db.Bicycles.Find(id);
            if (bicycles == null)
            {
                return NotFound();
            }

            db.Bicycles.Remove(bicycles);
            db.SaveChanges();

            return Ok(bicycles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BicyclesExists(int id)
        {
            return db.Bicycles.Count(e => e.ID == id) > 0;
        }
    }
}