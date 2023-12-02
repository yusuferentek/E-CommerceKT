using E_Commerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Interfaces
{
    internal interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
