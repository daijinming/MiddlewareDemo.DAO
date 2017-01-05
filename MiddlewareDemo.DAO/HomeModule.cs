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
                   var pagelist = repository.PagedList<Base_CodeRule>("select * from Base_CodeRule", orderString, page, rows);
                   result.Add("total", pagelist.TotalItemCount);
                   result.Add("rows", pagelist.Items);
                   return this.Response.AsJson<object>(result);
               };

            Post["/create"] = x =>
            {
                Base_CodeRule model = new Base_CodeRule();
                model.ModuleId = this.Request.Form.ModuleId;
                model.FullName = this.Request.Form.FullName;
                model.SortCode = this.Request.Form.SortCode;
                Dictionary<string, object> result = new Dictionary<string, object>();
                CommonRepository repository = new CommonRepository();
                var pagelist = repository.Save
                    (
                    "INSERT INTO [Base_CodeRule] (  [CodeRuleId],  [FullName],  [Code],  [ModuleId],  [Enabled],  [SortCode],  [DeleteMark],  [CreateDate],  [CreateUserId],  [CreateUserName],  [ModifyDate],  [ModifyUserId],  [ModifyUserName]) VALUES ( @CodeRuleId,  @FullName,  @Code,  @ModuleId,  @Enabled,  @SortCode,  @DeleteMark,  @CreateDate,  @CreateUserId,  @CreateUserName,  @ModifyDate,  @ModifyUserId,  @ModifyUserName)",
                    model
                    );
                result.Add("result", true);
                result.Add("message", "新增成功");

                return this.Response.AsJson<object>(result);
            };

            Post["/udpate"] = x =>
            {
                Base_CodeRule model = new Base_CodeRule();
                model.ModuleId = this.Request.Form.ModuleId;
                model.FullName = this.Request.Form.FullName;
                model.SortCode = this.Request.Form.SortCode;
                Dictionary<string, object> result = new Dictionary<string, object>();
                CommonRepository repository = new CommonRepository();
                var pagelist = repository.Save
                    (
                    "UPDATE [Base_CodeRule] SET [FullName] = @FullName, [Code] = @Code, [ModuleId] = @ModuleId, [Enabled] = @Enabled, [SortCode] = @SortCode, [DeleteMark] = @DeleteMark, [CreateDate] = @CreateDate, [CreateUserId] = @CreateUserId, [CreateUserName] = @CreateUserName, [ModifyDate] = @ModifyDate, [ModifyUserId] = @ModifyUserId, [ModifyUserName] = @ModifyUserName WHERE [CodeRuleId] = @CodeRuleId",
                    model
                    );
                result.Add("result", true);
                result.Add("message", "修改成功");

                return this.Response.AsJson<object>(result);
            };



        }
    }
}