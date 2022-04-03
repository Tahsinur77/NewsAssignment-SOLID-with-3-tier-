using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<T,ID>
    {
        bool Add(T obj);
        T Get(ID id);
        List<T> Get();
        bool Edit(T obj);
        bool Delete(ID id);
    }
}
