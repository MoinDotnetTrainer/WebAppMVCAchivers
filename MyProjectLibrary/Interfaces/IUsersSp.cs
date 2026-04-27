using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Interfaces
{
    public interface IUsersSp
    {
        Task AddUsers(Users data);// abs method
        Task<List<Users>> GetAllUsers();  // collection all records
        Task<Users> GetUserByID(int ID);// all data , we are gettig row data by id
        Task EditUsers(Users data);
        Task DeleteUser(int ID);

    }
}
