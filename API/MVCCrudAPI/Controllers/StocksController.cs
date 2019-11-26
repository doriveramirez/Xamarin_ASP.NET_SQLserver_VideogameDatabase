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
    public class StocksController : ApiController
    {
        private bicyclesEntities1 db = new bicyclesEntities1();

        // GET: api/Stocks
        public IQueryable<Stocks> GetStocks()
        {
            return db.Stocks;
        }

        // GET: api/Stocks/5
        [ResponseType(typeof(Stocks))]
        public IHttpActionResult GetStocks(int id)
        {
            Stocks stocks = db.Stocks.Find(id);
            if (stocks == null)
            {
                return NotFound();
            }

            return Ok(stocks);
        }

        // PUT: api/Stocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStocks(int id, Stocks stocks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stocks.BranchOfficesID)
            {
                return BadRequest();
            }

            db.Entry(stocks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StocksExists(id))
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

        // POST: api/Stocks
        [ResponseType(typeof(Stocks))]
        public IHttpActionResult PostStocks(Stocks stocks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stocks.Add(stocks);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StocksExists(stocks.BranchOfficesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stocks.BranchOfficesID }, stocks);
        }

        // DELETE: api/Stocks/5
        [ResponseType(typeof(Stocks))]
        public IHttpActionResult DeleteStocks(int id)
        {
            Stocks stocks = db.Stocks.Find(id);
            if (stocks == null)
            {
                return NotFound();
            }

            db.Stocks.Remove(stocks);
            db.SaveChanges();

            return Ok(stocks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StocksExists(int id)
        {
            return db.Stocks.Count(e => e.BranchOfficesID == id) > 0;
        }
    }
}