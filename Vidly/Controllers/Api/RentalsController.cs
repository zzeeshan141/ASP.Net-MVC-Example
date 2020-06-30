using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movies Ids provided.");

            var movies = _context.Movies.Where(s => newRental.MovieIds.Contains(s.Id)).ToList();
            if (movies.Count == 0)
                return BadRequest("Movies does not exists in database.");

            if (movies.Select(m => m.Id).Distinct().Count() != newRental.MovieIds.Distinct().Count())
                return BadRequest("Invalid one or more movies.");

            var customer = _context.Customers.SingleOrDefault(s => s.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer does not exists.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available.");

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                movie.NumberInStock--;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
