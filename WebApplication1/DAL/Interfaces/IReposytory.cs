using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public interface IReposytory<T>
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int id);
    }
}
