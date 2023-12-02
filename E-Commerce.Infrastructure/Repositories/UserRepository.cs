using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Interfaces;
using E_Commerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
