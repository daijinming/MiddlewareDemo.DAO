using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebModular.DAO;
using MiddlewareDemo.DAO.Models;
using Nancy;

namespace MiddlewareDemo.DAO
{
    public class HomeModule:Nancy.NancyModule
    {

        public HomeModule()
        {

            Post["/pagelist"] = x =>
               {
                   int page = this.Request.Form.page == null ? 1 : int.Parse(this.Request.Form.page);
                   int rows = this.Request.Form.rows == null ? 10 : int.Parse(this.Request.Form.rows);

                   string sort = this.Request.Form.sort == null ? "" : this.Request.Form.sort;
                   string order = this.Request.Form.order == null ? "" : this.Request.Form.order;

                   string orderString = order;
                   if (!string.IsNullOrWhiteSpace(orderString))
                       orderString = sort + " " + orderString;
                   else
                       orderString = "SortCode";

                   Dictionary<string, object> result = new Dictionary<string, object>();


                   CommonRepository repository = new CommonRepository();
                   
                   
                   return this.Response.AsJson<object>(null);
               };
        }
    }
}