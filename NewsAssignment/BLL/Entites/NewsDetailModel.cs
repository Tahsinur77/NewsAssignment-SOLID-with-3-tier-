using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class NewsDetailModel
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public Nullable<int> React { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    }
}
