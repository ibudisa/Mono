using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRepository<T> where T:class,new()
    {
       //IList<T> GetAll(int page = 1,int itemsPerPage = 30, string sortBy = "FirstName", bool reverse = false, string search = null);
       //T GetOne(int id);
       void Add(T value);
       void Update(T value);
       //void Delete(int id);
    }
}
