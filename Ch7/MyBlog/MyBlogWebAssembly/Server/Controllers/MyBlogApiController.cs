using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebAssembly.Server.Controllers
{
    public class MyBlogApi:Controller
    {
        //<Constructor>
        public IMyBlogApi api { get; set; }
        public MyBlogApi(IMyBlogApi api)
        {
            this.api = api;
        }
        //</Constructor>
      
    }
}
