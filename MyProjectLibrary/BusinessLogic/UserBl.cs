using Microsoft.EntityFrameworkCore;
using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.BusinessLogic
{
    public class UserBl : IUsers
    {
        private readonly AppDb _db;
        public UserBl(AppDb db)
        {
            _db = db;
        }

        // async



        public async Task AddUsers(Models.Users data)
        {
            await _db.Users.AddAsync(data);
            await _db.SaveChangesAsync();

            // chk db , table , prop , data 
            // implemnet abs method
            // insert ops // we will EF core
        }

        public async Task<List<Users>> GetAllUsers()
        {

            // syntax to get all data using linq

            //  return await _db.Users.ToListAsync();

            var res = await (from s in _db.Users select s).ToListAsync();
            return res;

        }
    }
}
