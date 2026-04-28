using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.BusinessLogic
{
    public class CountryBl : ICountry
    {
        public readonly AppDb _db;
        public CountryBl(AppDb db)
        {
            _db = db;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _db.Country.Include(x => x.States).ToListAsync();  // eager load
        }

        public async Task<List<Country>> GetCountriesAsyncLazy()
        {
            return await _db.Country.ToListAsync();

           

            // step 2 states --> lazy loading --> hit database
        }
    }
}
