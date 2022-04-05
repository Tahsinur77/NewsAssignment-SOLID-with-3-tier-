using BLL.Entites;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAssignment.Controllers
{
    public class NewsController : ApiController
    {
        [Route("api/News/Add")]
        [HttpPost]
        public HttpResponseMessage Add(NewsModel news)
        {
            if (ModelState.IsValid)
            {
               var flag =  NewsService.Add(news);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/News/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = NewsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/News/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = NewsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/News/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(NewsModel news)
        {
            if (ModelState.IsValid)
            {
                var flag = NewsService.Edit(news);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/News/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = NewsService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }

        [Route("api/News/Search")]
        [HttpPost]
        public HttpResponseMessage Search(string category,string date)
        {
            var searchList = NewsService.Search(category,date);
            return Request.CreateResponse(HttpStatusCode.OK, searchList);
        }

        [Route("api/News/Comment")]
        [HttpPost]
        public HttpResponseMessage AddComment(string comment, int newsId, int userId)
        {
            var flag = NewsService.AddComment(comment, newsId, userId);
            if(flag) return Request.CreateResponse(HttpStatusCode.OK, "Comment Added");
            return Request.CreateResponse(HttpStatusCode.OK, "Comment not added");
        }

        [Route("api/News/React")]
        [HttpPost]
        public HttpResponseMessage AddReact(int react, int newsId, int userId)
        {
            var flag = NewsService.AddReact(react, newsId, userId);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "React Added");
            return Request.CreateResponse(HttpStatusCode.OK, "React not added");
        }

        [Route("api/News/GetComment/{id}")]
        [HttpGet]
        public HttpResponseMessage GetComment(int id)
        {
            var comment = NewsService.GetCommnet(id);
            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        [Route("api/News/GetReact/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReact(int id)
        {
            var react = NewsService.GetReact(id);
            return Request.CreateResponse(HttpStatusCode.OK, react);
        }

    }
}
