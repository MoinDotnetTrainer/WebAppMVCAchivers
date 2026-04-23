using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.BusinessLogic
{
    public class MoviesBl : IMovies
    {
        private readonly AppDb _db;
        public MoviesBl(AppDb db)
        {
            _db = db;
        }
        public async Task AddMovies(Models.Movies data)
        {
            await _db.Movies.AddAsync(data);
            await _db.SaveChangesAsync();
        }
    }
}
