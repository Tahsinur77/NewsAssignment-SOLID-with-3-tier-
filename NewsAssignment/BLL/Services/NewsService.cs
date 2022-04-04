using AutoMapper;
using BLL.Entites;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        public static NewsModel Get(int newsId)
        {
            var news = DataAccessFactory.NewsDataAccess().Get(newsId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var newsModel = mapper.Map<NewsModel>(news);

            return newsModel;
        }

        public static List<NewsModel> Get()
        {
            var newsList = DataAccessFactory.NewsDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var newsModelList = mapper.Map<List<NewsModel>>(newsList);

            return newsModelList;

        }

        public static bool Add(NewsModel newsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            var mapper = new Mapper(config);
            var news = mapper.Map<News>(newsModel);

            var check = DataAccessFactory.NewsDataAccess().Add(news);
            return check;
        }

        public static bool Edit(NewsModel newsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            var mapper = new Mapper(config);
            var news = mapper.Map<News>(newsModel);

            var flag = DataAccessFactory.NewsDataAccess().Edit(news);
            return flag;
        }

        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.NewsDataAccess().Delete(id);
            return flag;
        }

        public static List<NewsModel> Search(string category,string date)
        {
            var newsList = DataAccessFactory.NewsSearchAccess().Get(category, date);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var newsModelList = mapper.Map<List<NewsModel>>(newsList);
            return newsModelList;
        }

        public static bool AddComment(string comment,int newsId,int userId)
        {
            var flag = DataAccessFactory.NewsSocialAccess().AddComment(comment, newsId, userId);
            return flag;
        }

        public static bool AddReact(int react,int newsId,int userId)
        {
            var flag = DataAccessFactory.NewsSocialAccess().AddReact(react, newsId, userId);
            return flag;
        }

        public static List<NewsDetailUserModel> GetCommnet(int newsId)
        {
            var newsDetails = DataAccessFactory.NewsSocialAccess().GetComment(newsId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);

            List<NewsDetailUserModel> list = new List<NewsDetailUserModel>();

            foreach (var x in newsDetails)
            {
                NewsDetailUserModel n = new NewsDetailUserModel();
                n.Id = x.Id;
                n.NewsId = x.NewsId;
                n.React = x.React;
                n.Comment = x.Comment;
                n.UserId = x.UserId;
                n.User = mapper.Map<UserModel>(x.User);

                list.Add(n);
            }

            return list;

        }


        public static List<NewsDetailUserModel> GetReact(int newsId)
        {
            var newsDetails = DataAccessFactory.NewsSocialAccess().GetReact(newsId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);

            List<NewsDetailUserModel> list = new List<NewsDetailUserModel>();

            foreach (var x in newsDetails)
            {
                NewsDetailUserModel n = new NewsDetailUserModel();
                n.Id = x.Id;
                n.NewsId = x.NewsId;
                n.React = x.React;
                n.Comment = x.Comment;
                n.UserId = x.UserId;
                n.User = mapper.Map<UserModel>(x.User);

                list.Add(n);
            }

            return list;

        }


    }
}
