using DAL.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo:IRepository<News,int>,ISearch<News>,ISocial<NewsDetail,int,int>
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
                            where x.Date.Equals(date)
                            select x).ToList();
                return list;
            }
            else if(date == "" || date == null)
            {
                var list = (from x in db.News
                            where x.Category.Equals(category)
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
        public bool AddComment(string comment,int newsId, int userId)
        {
            NewsDetail newsDetails = new NewsDetail();
            newsDetails.NewsId = newsId;
            newsDetails.UserId = userId;
            newsDetails.React = null;
            newsDetails.Comment = comment;
            db.NewsDetails.Add(newsDetails);
            if (db.SaveChanges() != 0) return true;
            return false;
            
        }

        public bool AddReact(int react,int newsId, int userId)
        {
            NewsDetail newsDetails = new NewsDetail();
            newsDetails.NewsId = newsId;
            newsDetails.UserId = userId;
            newsDetails.React = react;
            newsDetails.Comment = null;
            db.NewsDetails.Add(newsDetails);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public List<NewsDetail> GetComment(int id1)
        {
            var newsdetails = (from x in db.NewsDetails
                               where x.NewsId.Equals(id1)
                               && x.Comment != null
                               select x).ToList();
            return newsdetails;
        }

        public List<NewsDetail> GetReact(int id1)
        {
            var newsdetails = (from x in db.NewsDetails
                               where x.NewsId.Equals(id1)
                               && x.React != null
                               select x).ToList();
            return newsdetails;
        }
    }
}
