using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }
    }
}
