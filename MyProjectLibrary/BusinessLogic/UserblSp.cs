using Microsoft.Data.SqlClient;
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
    public class UserblSp : IUsersSp
    {
        public readonly AppDb _db;
        public UserblSp(AppDb db)
        {
            _db = db;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            string sql = "exec Sp_GetAllData";
            return await _db.Users.FromSqlRaw(sql).ToListAsync();
        }


        public async Task AddUsers(Users Data)
        {
            string Sql = "Exec Sp_Insert @Name ,@Email , @Password ,@Dob";
            List<SqlParameter> Paras = new List<SqlParameter>() {
            new SqlParameter { ParameterName="@Name",Value=Data.Name},
            new SqlParameter { ParameterName="@Email",Value=Data.Email},
            new SqlParameter { ParameterName="@Password",Value=Data.Password},
            new SqlParameter { ParameterName="@Dob",Value=Data.Dob}
            };
            await _db.Database.ExecuteSqlRawAsync(Sql, Paras.ToArray());
        }

        public async Task<Users> GetUserByID(int ID)
        {
            string sql = "exec Sp_GetAllDataByID @ID";

            var res = _db.Users
                .FromSqlRaw(sql, new SqlParameter("@ID", ID))
                .AsEnumerable()   // switch to client-side
                .FirstOrDefault();


            //  iEnumrable   , IQuerable  --> get the data from source
            return res;
        }

        public async Task EditUsers(Users Data)
        {
            string Sql = "Exec Sp_Update @ID ,@Name ,@Email , @Password ,@Dob";
            List<SqlParameter> Paras = new List<SqlParameter>() {
            new SqlParameter { ParameterName="@ID",Value=Data.ID},
            new SqlParameter { ParameterName="@Name",Value=Data.Name},
            new SqlParameter { ParameterName="@Email",Value=Data.Email},
            new SqlParameter { ParameterName="@Password",Value=Data.Password},
            new SqlParameter { ParameterName="@Dob",Value=Data.Dob}
            };
            await _db.Database.ExecuteSqlRawAsync(Sql, Paras.ToArray());
        }

        public async Task DeleteUser(int ID)
        {
            string Sql = "Exec Sp_Delete @ID";
            await _db.Database.ExecuteSqlRawAsync(Sql, new SqlParameter("@ID", ID));
        }
    }
}
