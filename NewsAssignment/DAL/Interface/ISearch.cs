using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ISearch<T>
    {
        List<T> Get(string category,string date);
    }
}
