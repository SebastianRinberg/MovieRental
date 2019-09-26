using AutoMapper;
using MovieRental.Dtos;
using MovieRental.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;


namespace MovieRental.Controllers.Api
{
    public class SeriesController : ApiController
    {
        private ApplicationDbContext _context;
        public SeriesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /Api/series
        public IHttpActionResult GetSeries()
        {
            var seriesDtos = _context.Series
                .Include(s => s.Genre)
                .ToList()
                .Select(Mapper.Map<Series, SeriesDto>);
            return Ok(seriesDtos);
        }

        // GET /Api/series/1
        public IHttpActionResult GetSeriesById(int id)
        {
            var series = _context.Series
                .SingleOrDefault(c => c.Id == id);

            if (series == null)
                return NotFound();

            return Ok(Mapper.Map<Series, SeriesDto>(series));
        }

        // POST /Api/series
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateSeries(SeriesDto seriesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var series = Mapper.Map<SeriesDto, Series>(seriesDto);
            _context.Series.Add(series);
            _context.SaveChanges();

            seriesDto.Id = series.Id;
            return Created(new Uri(Request.RequestUri + "/" + seriesDto.Id), seriesDto);
        }

        // PUT /Api/series/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateSeries(int id, SeriesDto seriesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var seriesInDb = _context.Series.SingleOrDefault(s => s.Id == id);
            if (seriesInDb == null)
                return NotFound();

            Mapper.Map(seriesDto, seriesInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /Api/series/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteSeries(int id)
        {
            var seriesInDb = _context.Series.SingleOrDefault(s => s.Id == id);
            if (seriesInDb == null)
                return NotFound();

            _context.Series.Remove(seriesInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
