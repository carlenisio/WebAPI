using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class AnalistasController : ApiController
    {
        static readonly IAnalistaRepositorio analistaRepositorio = new AnalistaRepositorio();
        private AnalistaDBContext db = new AnalistaDBContext();

        // GET: api/Analistas
        public IQueryable<Analista> GetAnalistas()
        {
            return db.Analistas;
        }
        // GET: api/Analistas/5
        [ResponseType(typeof(Analista))]
        public IHttpActionResult GetAnalista(int id)
        {
            Analista analista = db.Analistas.Find(id);
            if (analista == null)
            {
                return NotFound();
            }
            return Ok(analista);
        }
        // PUT: api/Analistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnalista(int id, Analista analista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != analista.id)
            {
                return BadRequest();
            }
            db.Entry(analista).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalistaExists(id))
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


        // POST: api/analistas
        [ResponseType(typeof(Analista))]
        public IHttpActionResult PostAnalista(Analista analista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Analistas.Add(analista);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = analista.id }, analista);
        }

        // DELETE: api/Analistas/5
        [ResponseType(typeof(Analista))]
        public IHttpActionResult DeleteAnalista(int id)
        {
            Analista analista = db.Analistas.Find(id);
            if (analista == null)
            {
                return NotFound();
            }

            db.Analistas.Remove(analista);
            db.SaveChanges();

            return Ok(analista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnalistaExists(int id)
        {
            return db.Analistas.Count(e => e.id == id) > 0;
        }
    }
}