using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Interfaces
{
    public interface IUsers
    {
        // Add
        // Update
        // Get 
        // Delete
        // xyz task
        Task AddUsers(Users data);// abs method

        Task<List<Users>> GetAllUsers();  // collection all records


        // insert Ef
        //Task UpdateUsers(Users data);
        //Task<Users> GetUsers(int id);
        //Task DeleteUsers(int id);   
    }
}
