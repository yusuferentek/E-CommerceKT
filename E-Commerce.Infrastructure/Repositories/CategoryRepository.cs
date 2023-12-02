﻿using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Interfaces;
using E_Commerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
