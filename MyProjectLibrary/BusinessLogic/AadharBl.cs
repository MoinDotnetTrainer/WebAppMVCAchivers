using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.BusinessLogic
{
    public class AadharBl : IAadhar
    {
        public readonly AppDb _db;
        public AadharBl(AppDb db)
        {
            _db = db;
        }

        public async Task<List<Aadhar>> GetAadharData()
        {

            // include 
            return await _db.Aadhar.Include("Pan").ToListAsync();
          
        }
        public async Task<List<Pan>> GetPanData()
        {

            // include 
            return await _db.Pan.Include("Aadhar").ToListAsync();
          
        }

    }
}
