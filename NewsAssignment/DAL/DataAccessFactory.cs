using DAL.Database;
using DAL.Interface;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static NewsApiEntities db = new NewsApiEntities();

        public static IRepository<News,int> NewsDataAccess()
        {
            return new NewsRepo(db);
        }

        public static ISearch<News> NewsSearchAccess()
        {
            return new NewsRepo(db);
        }

        public static ISocial<NewsDetail,int,int> NewsSocialAccess()
        {
            return new NewsRepo(db);
        }
    }
}
