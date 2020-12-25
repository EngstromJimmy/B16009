using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//<using>
using MyBlog.Data.Interfaces;
using System.Net.Http;
using MyBlog.Data.Models;
//</using>
namespace MyBlog.Data
{
    public class MyBlogApiClientSide:IMyBlogApi
    {
        //<Constructor>
        HttpClient httpclient;
        public MyBlogApiClientSide(HttpClient httpclient)
        {
            this.httpclient = httpclient;
        }
        //</Constructor>
    }
}
