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
    public class BranchOfficesController : ApiController
    {
        private bicyclesEntities1 db = new bicyclesEntities1();

        // GET: api/BranchOffices
        public IQueryable<BranchOffices> GetBranchOffices()
        {
            return db.BranchOffices;
        }

        // GET: api/BranchOffices/5
        [ResponseType(typeof(BranchOffices))]
        public IHttpActionResult GetBranchOffices(int id)
        {
            BranchOffices branchOffices = db.BranchOffices.Find(id);
            if (branchOffices == null)
            {
                return NotFound();
            }

            return Ok(branchOffices);
        }

        // PUT: api/BranchOffices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBranchOffices(int id, BranchOffices branchOffices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branchOffices.ID)
            {
                return BadRequest();
            }

            db.Entry(branchOffices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchOfficesExists(id))
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

        // POST: api/BranchOffices
        [ResponseType(typeof(BranchOffices))]
        public IHttpActionResult PostBranchOffices(BranchOffices branchOffices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BranchOffices.Add(branchOffices);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = branchOffices.ID }, branchOffices);
        }

        // DELETE: api/BranchOffices/5
        [ResponseType(typeof(BranchOffices))]
        public IHttpActionResult DeleteBranchOffices(int id)
        {
            BranchOffices branchOffices = db.BranchOffices.Find(id);
            if (branchOffices == null)
            {
                return NotFound();
            }

            db.BranchOffices.Remove(branchOffices);
            db.SaveChanges();

            return Ok(branchOffices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchOfficesExists(int id)
        {
            return db.BranchOffices.Count(e => e.ID == id) > 0;
        }
    }
}