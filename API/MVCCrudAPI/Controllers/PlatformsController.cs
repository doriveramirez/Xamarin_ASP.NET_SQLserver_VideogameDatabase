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
    public class PlatformsController : ApiController
    {
        private VideogamesDBEntities db = new VideogamesDBEntities();

        // GET: api/Platforms
        public IQueryable<Platforms> GetPlatforms()
        {
            return db.Platforms;
        }

        // GET: api/Platforms/5
        [ResponseType(typeof(Platforms))]
        public IHttpActionResult GetPlatforms(string id)
        {
            Platforms platforms = db.Platforms.Find(id);
            if (platforms == null)
            {
                return NotFound();
            }

            return Ok(platforms);
        }

        // PUT: api/Platforms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlatforms(string id, Platforms platforms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platforms.Id)
            {
                return BadRequest();
            }

            db.Entry(platforms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformsExists(id))
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

        // POST: api/Platforms
        [ResponseType(typeof(Platforms))]
        public IHttpActionResult PostPlatforms(Platforms platforms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Platforms.Add(platforms);

            try
            {
                Console.WriteLine("Id" + platforms.Id + "Nombre" + platforms.Name + "ReleaseDate" + platforms.ReleaseDate + "Descripción" + platforms.Description + "Sold units" + platforms.SoldUnits);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlatformsExists(platforms.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = platforms.Id }, platforms);
        }

        // DELETE: api/Platforms/5
        [ResponseType(typeof(Platforms))]
        public IHttpActionResult DeletePlatforms(string id)
        {
            Platforms platforms = db.Platforms.Find(id);
            if (platforms == null)
            {
                return NotFound();
            }

            db.Platforms.Remove(platforms);
            db.SaveChanges();

            return Ok(platforms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlatformsExists(string id)
        {
            return db.Platforms.Count(e => e.Id == id) > 0;
        }
    }
}