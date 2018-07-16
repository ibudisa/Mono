using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IRepository<T> where T:class,new()
    {
       IList<T> GetAll();
       //T GetOne(int id);
       void Add(T value);
       void Update(T value);
       //void Delete(int id);
    }
}
