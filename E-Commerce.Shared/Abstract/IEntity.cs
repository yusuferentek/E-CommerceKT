using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Abstract
{
    public interface IEntity : IEntity<int>
    {
    }

    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
