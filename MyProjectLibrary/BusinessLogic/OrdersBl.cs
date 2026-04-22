using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.BusinessLogic
{
    public class OrdersBl : IOrders
    {
        private readonly AppDb _db;

        public OrdersBl(AppDb db)
        {
            _db = db;
        }

        public async Task AddOrders(Models.Orders data)
        {
            await _db.Orders.AddAsync(data);
            await _db.SaveChangesAsync();
        }
    }
}
