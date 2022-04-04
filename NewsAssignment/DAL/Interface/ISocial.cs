using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ISocial<T,ID1,ID2>
    {
        bool AddComment(string comment,ID1 newsId,ID2 userId);
        bool AddReact(int react,ID1 newsId, ID2 userId);

        List<T> GetComment(ID1 newsId);
        List<T> GetReact(ID1 newsId);

    }
}
