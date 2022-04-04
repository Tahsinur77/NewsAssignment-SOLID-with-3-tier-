using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class NewsDetailUserModel:NewsDetailModel
    {
        public UserModel User { set; get; }

        public NewsDetailUserModel()
        {
            this.User = new UserModel();
        }
    }
}
