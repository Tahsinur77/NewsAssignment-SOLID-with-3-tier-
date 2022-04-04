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

    }
}
