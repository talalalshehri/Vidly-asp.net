﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
           

            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or movieIds are invalid.");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available"); 
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now

                };
                _context.Rentals.Add(rental); 
            }
            _context.SaveChanges();
            return Ok(); 
            
        }
    }
}
