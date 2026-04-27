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

            return await _db.Users.AsNoTracking().ToListAsync();

            // var res = await (from s in _db.Users select s).ToListAsync();
            // return res;

            // diff complex queries using linq
            // joins , order by t get the data
            // merge Union etc 

        }

        public async Task<Users> GetUserByID(int ID)
        {
            var res = await (from s in _db.Users select s).FirstOrDefaultAsync(x => x.ID == ID);
            return res;
        }

        public async Task EditUsers(Users data)
        {
            var res = await _db.Users.Where(x => x.ID == data.ID).AsNoTracking().FirstOrDefaultAsync();
            // is now tracked by ef core
            var newrec = new Users
            {
                ID = res.ID,
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                Dob = data.Dob
            };
            _db.Users.Update(newrec);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteUser(int ID)
        {
            var res = await _db.Users.FindAsync(ID);
            if (res != null)
            {
                _db.Users.Remove(res);// await
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> UserLogin(LoginModel data)
        {
            var res = await (from s in _db.Users select s).AnyAsync(x => x.Email == data.Email && x.Password == data.Password);
            return res;
        }
    }
}