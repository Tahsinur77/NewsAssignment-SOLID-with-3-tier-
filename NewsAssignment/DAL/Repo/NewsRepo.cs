using DAL.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo:IRepository<News,int>,ISearch<News>
    {
        private NewsApiEntities db;

        public NewsRepo(NewsApiEntities db)
        {
            this.db = db;
        }

        public bool Add(News obj)
        {
            db.News.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.News.FirstOrDefault(x => x.Id == id);
            db.News.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(News obj)
        {
            var old = db.News.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public News Get(int id)
        {
            return db.News.FirstOrDefault(x => x.Id == id);
        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public List<News> Get(string category, string date)
        {
            if(category == "" || category == null)
            {
                var list = (from x in db.News
                            where x.Category.Equals(category)
                            select x).ToList();
                return list;
            }
            else if(date == "" || date == null)
            {
                var list = (from x in db.News
                            where x.Date.Equals(date)
                            select x).ToList();
                return list;
            }
            else
            {
                var list = (from x in db.News
                            where x.Category.Equals(category) && 
                            x.Date.Equals(date)
                            select x).ToList();
                return list;
            }
        }
    }
}
