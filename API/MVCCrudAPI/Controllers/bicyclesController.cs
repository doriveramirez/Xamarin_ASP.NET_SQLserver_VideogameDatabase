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
    public class bicyclesController : ApiController
    {
        private bicyclesEntities db = new bicyclesEntities();

        // GET: api/bicycles
        public IQueryable<bicycles> Getbicycles()
        {
            return db.bicycles;
        }

        // GET: api/bicycles/5
        [ResponseType(typeof(bicycles))]
        public IHttpActionResult Getbicycles(int id)
        {
            bicycles bicycles = db.bicycles.Find(id);
            if (bicycles == null)
            {
                return NotFound();
            }

            return Ok(bicycles);
        }

        // PUT: api/bicycles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbicycles(int id, bicycles bicycles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bicycles.id)
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
                if (!bicyclesExists(id))
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

        // POST: api/bicycles
        [ResponseType(typeof(bicycles))]
        public IHttpActionResult Postbicycles(bicycles bicycles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bicycles.Add(bicycles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bicycles.id }, bicycles);
        }

        // DELETE: api/bicycles/5
        [ResponseType(typeof(bicycles))]
        public IHttpActionResult Deletebicycles(int id)
        {
            bicycles bicycles = db.bicycles.Find(id);
            if (bicycles == null)
            {
                return NotFound();
            }

            db.bicycles.Remove(bicycles);
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

        private bool bicyclesExists(int id)
        {
            return db.bicycles.Count(e => e.id == id) > 0;
        }
    }
}