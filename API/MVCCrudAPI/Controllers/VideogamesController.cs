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
    public class VideogamesController : ApiController
    {
        private VideogamesDBEntities db = new VideogamesDBEntities();

        // GET: api/Videogames
        public IQueryable<Videojuego> GetVideojuego()
        {
            return db.Videojuego;
        }

        // GET: api/Videogames/5
        [ResponseType(typeof(Videojuego))]
        public IHttpActionResult GetVideojuego(string id)
        {
            Videojuego videojuego = db.Videojuego.Find(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return Ok(videojuego);
        }

        // PUT: api/Videogames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideojuego(string id, Videojuego videojuego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videojuego.Id)
            {
                return BadRequest();
            }

            db.Entry(videojuego).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideojuegoExists(id))
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

        // POST: api/Videogames
        [ResponseType(typeof(Videojuego))]
        public IHttpActionResult PostVideojuego(Videojuego videojuego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Videojuego.Add(videojuego);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VideojuegoExists(videojuego.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = videojuego.Id }, videojuego);
        }

        // DELETE: api/Videogames/5
        [ResponseType(typeof(Videojuego))]
        public IHttpActionResult DeleteVideojuego(string id)
        {
            Videojuego videojuego = db.Videojuego.Find(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            db.Videojuego.Remove(videojuego);
            db.SaveChanges();

            return Ok(videojuego);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideojuegoExists(string id)
        {
            return db.Videojuego.Count(e => e.Id == id) > 0;
        }
    }
}