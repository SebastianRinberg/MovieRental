using AutoMapper;
using MovieRental.Dtos;
using MovieRental.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MovieRental.Controllers.Api
{
    public class DocumentariesController : ApiController
    {
        private ApplicationDbContext _context;
        public DocumentariesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/documentaries
        public IHttpActionResult GetDocumentaries()
        {
            var documentaryDtos = _context.Documentaries
                .Include(d => d.DocumentaryGenre)
                .ToList()
                .Select(Mapper.Map<Documentary, DocumentaryDto>);
            return Ok(documentaryDtos);
        }

        // GET /api/documentaries/1
        public IHttpActionResult GetDocumentary(int id)
        {
            var documentary = _context.Documentaries.SingleOrDefault(d => d.Id == id);
            if (documentary == null)
                return NotFound();

            return Ok(Mapper.Map<Documentary, DocumentaryDto>(documentary));
        }

        // POST /api/documentaries
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateDocumentary(DocumentaryDto documentaryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var documentary = Mapper.Map<DocumentaryDto, Documentary>(documentaryDto);
            _context.Documentaries.Add(documentary);
            _context.SaveChanges();

            documentaryDto.Id = documentary.Id;
            return Created(new Uri(Request.RequestUri + "/" + documentary.Id), documentaryDto);
        }

        // PUT /api/documentaries/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateDocumentary(int id, DocumentaryDto documentaryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var documentaryInDb = _context.Documentaries.SingleOrDefault(d => d.Id == id);

            if (documentaryInDb == null)
                return NotFound();

            Mapper.Map(documentaryDto, documentaryInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/documentaries/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteDocumentary(int id)
        {
            var documentaryInDb = _context.Documentaries.SingleOrDefault(d => d.Id == id);
            if (documentaryInDb == null)
                return NotFound();

            _context.Documentaries.Remove(documentaryInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
